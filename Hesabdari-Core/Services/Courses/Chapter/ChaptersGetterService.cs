using ServiceContracts;
using Hesabdari_Core.DTO;
using RepositoryContracts;

namespace Services
{
    public class ChaptersGetterService : IChaptersGetterService
    {
        private readonly ITestimonialsRepository _testimonialsRepository;

        public ChaptersGetterService(ITestimonialsRepository testimonialsRepository)
        {
            _testimonialsRepository = testimonialsRepository;
        }

        public virtual async Task<ItemsResult<TestimonialResult>> GetTestimonials()
        {
            var testimonials = await _testimonialsRepository.GetTestimonials();

            return new ItemsResult<TestimonialResult>(
                                                      testimonials.Select(x =>
                                                                              new TestimonialResult(x.Id, x.PositionAndCompany, x.Content, x.ImageUrl, x.Order, x.IsActive)
                                                                         ).ToList()
                                                     );
        }

        public virtual async Task<ItemsResult<TestimonialDashboardResult>> GetDashboardTestimonials()
        {
            var testimonials = await _testimonialsRepository.GetDashboardTestimonials();

            return new ItemsResult<TestimonialDashboardResult>(
                                                               testimonials.Select(x =>
                                                                                       new TestimonialDashboardResult(x.Id, x.PositionAndCompany, x.Content, x.ImageUrl, x.Order)
                                                                                  ).ToList()
                                                              );
        }
    }
}