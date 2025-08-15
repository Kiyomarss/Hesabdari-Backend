using Hesabdari_Core.Domain.Entities;

namespace RepositoryContracts;

public interface ITestimonialsRepository
{
    Task<Testimonial> AddTestimonial(Testimonial testimonial);

    Task UpdateTestimonial();

    Task<List<Testimonial>> GetTestimonials();

    Task<List<Testimonial>> GetDashboardTestimonials();
    
    Task<Testimonial?> FindTestimonialById(int testimonialId);

    Task<bool> DeleteTestimonial(int testimonialId);
    
    Task<bool> DeleteImageTestimonial(int testimonialId);
}