using Hesabdari_Core.Domain.Entities;
using Hesabdari_Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using RepositoryContracts;

namespace Repositories
{
    public class UserCoursesRepository : RepositoryBase, IUserCoursesRepository
    {
        private readonly IApplicationDbContext _db;

        public UserCoursesRepository(IApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<UserCourse> AddUserCourse(UserCourse userCourse)
        {
            await _db.Set<UserCourse>().AddAsync(userCourse);

            await _db.SaveChangesAsync();
            
            return userCourse;
        }

        public async Task<List<UserCourse>> GetUserCourses()
        {
            return await _db.Set<UserCourse>().ToListAsync();
        }
        
        public async Task<List<Course>> FindCoursesByUserId(Guid userId)
        {
            return await _db.Set<UserCourse>()
                            .Where(x => x.UserId == userId)
                            .Include(x => x.Course)
                            .Select(x => x.Course)
                            .ToListAsync();
        }

        public async Task<bool> DeleteUserCourseAsync(int courseId, Guid userId)
        {
            var rowsDeleted = await _db.Set<UserCourse>()
                                       .Where(b => b.CourseId == courseId && b.UserId == userId)
                                       .ExecuteDeleteAsync();

            return rowsDeleted > 0;
        }
    }
}