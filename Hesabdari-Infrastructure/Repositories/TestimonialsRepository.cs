using Hesabdari_Core.Domain.Entities;
using Hesabdari_Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using RepositoryContracts;

namespace Repositories
{
    public class TestimonialsRepository : RepositoryBase, ITestimonialsRepository
    {
        private readonly IApplicationDbContext _db;

        public TestimonialsRepository(IApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Testimonial> AddTestimonial(Testimonial testimonial)
        {
            await _db.Set<Testimonial>().AddAsync(testimonial);

            await _db.SaveChangesAsync();
            
            return testimonial;
        }

        public Task UpdateTestimonial()
        {
            return _db.SaveChangesAsync();
        }

        public async Task<List<Testimonial>> GetTestimonials()
        {
            return await _db.Set<Testimonial>()
                            .OrderBy(x => x.Order).ToListAsync();
        }
        
        public async Task<List<Testimonial>> GetDashboardTestimonials()
        {
            return await _db.Set<Testimonial>().Where(b => b.IsActive)
                            .OrderBy(x => x.Order).ToListAsync();
        }
        
        public async Task<Testimonial?> FindTestimonialById(int testimonialId)
        {
            return await _db.Set<Testimonial>().FindAsync(testimonialId);
        }

        public async Task<bool> DeleteTestimonial(int testimonialId)
        {
            var rowsDeleted = await _db.Set<Testimonial>()
                                       .Where(b => b.Id == testimonialId)
                                       .ExecuteDeleteAsync();

            return rowsDeleted > 0;
        }
        
        public async Task<bool> DeleteImageTestimonial(int testimonialId)
        {
            var rowsDeleted = await _db.Set<Testimonial>()
                                       .Where(b => b.Id == testimonialId)
                                       .ExecuteDeleteAsync();

            return rowsDeleted > 0;
        }
    }
}