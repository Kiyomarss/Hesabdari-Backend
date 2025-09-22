using Hesabdari_Core.Domain.Entities;
using Hesabdari_Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using RepositoryContracts;

namespace Repositories
{
    public class LessonsRepository : RepositoryBase, ILessonsRepository
    {
        private readonly IApplicationDbContext _db;

        public LessonsRepository(IApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Lesson> AddLesson(Lesson lesson)
        {
            await _db.Set<Lesson>().AddAsync(lesson);

            await _db.SaveChangesAsync();
            
            return lesson;
        }
        
        public async Task<Lesson?> FindLessonById(int lessonId)
        {
            return await _db.Set<Lesson>().FindAsync(lessonId);
        }

        public Task UpdateLesson()
        {
            return _db.SaveChangesAsync();
        }

        public async Task<bool> DeleteLesson(int lessonId)
        {
            var rowsDeleted = await _db.Set<Lesson>()
                                       .Where(b => b.Id == lessonId)
                                       .ExecuteDeleteAsync();

            return rowsDeleted > 0;
        }
    }
}