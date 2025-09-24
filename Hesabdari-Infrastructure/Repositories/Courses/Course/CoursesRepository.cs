using Hesabdari_Core.Domain.Entities;
using Hesabdari_Core.DTO;
using Hesabdari_Core.Utils;
using Hesabdari_Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using RepositoryContracts;

namespace Repositories
{
    public class CoursesRepository : RepositoryBase, ICoursesRepository
    {
        private readonly IApplicationDbContext _db;

        public CoursesRepository(IApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Course> AddCourse(Course course)
        {
            await _db.Set<Course>().AddAsync(course);

            await _db.SaveChangesAsync();
            
            return course;
        }

        public Task UpdateCourse()
        {
            return _db.SaveChangesAsync();
        }

        public async Task<List<CourseSummaryDto>> GetCoursesAsync()
        {
            return await _db.Set<Course>()
                            .Select(c => new CourseSummaryDto
                            {
                                Id = c.Id,
                                Title = c.Title,
                                ShortDescription = c.ShortDescription,
                                Price = c.Price,
                                ImageUrl = c.ImageUrl
                            })
                            .ToListAsync();
        }
        
        public async Task<List<CourseSummaryDto>> GetCoursesAsync(List<int> courseIds)
        {
            return await _db.Set<Course>()
                            .Where(c => courseIds.Contains(c.Id))
                            .Select(c => new CourseSummaryDto
                            {
                                Id = c.Id,
                                Title = c.Title,
                                ShortDescription = c.ShortDescription,
                                Price = c.Price,
                                ImageUrl = c.ImageUrl
                            })
                            .ToListAsync();
        }
        
        public async Task<CourseResultDto> GetCourseByIdAsync(int courseId)
        {
            return await _db.Set<Course>()
                            .Where(c => c.Id == courseId)
                            .Select(c => new CourseResultDto
                            {
                                Id = c.Id,
                                Title = c.Title,
                                ShortDescription = c.ShortDescription,
                                FullDescription = c.FullDescription,
                                Price = c.Price,
                                IntroVideoUrl = c.IntroVideoUrl,

                                Chapters = c.Chapters
                                            .OrderBy(ch => ch.Order)
                                            .Select(ch => new ChapterResultDto
                                            {
                                                Id = ch.Id,
                                                Title = ch.Title,
                                                Order = ch.Order,

                                                Lessons = ch.Lessons
                                                            .OrderBy(l => l.Order)
                                                            .Select(l => new LessonResultDto
                                                            {
                                                                Id = l.Id,
                                                                Title = l.Title,
                                                                Order = l.Order,
                                                                VideoUrl = l.VideoUrl,
                                                                Duration = l.Duration.ToDurationString()
                                                            }).ToList()
                                            }).ToList()
                            })
                            .FirstAsync();
        }
        public async Task<Course?> FindCourseById(int courseId)
        {
            return await _db.Set<Course>()
                            .Include(c => c.Chapters)
                            .ThenInclude(ch => ch.Lessons)
                            .FirstOrDefaultAsync(c => c.Id == courseId);
        }

        public async Task<bool> DeleteCourse(int courseId)
        {
            var rowsDeleted = await _db.Set<Course>()
                                       .Where(b => b.Id == courseId)
                                       .ExecuteDeleteAsync();

            return rowsDeleted > 0;
        }
    }
}