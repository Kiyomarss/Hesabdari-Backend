using Hesabdari_Core.Domain.Entities;
using Hesabdari_Core.DTO;
using Hesabdari_Core.ServiceContracts.Storage;
using ServiceContracts;
using RepositoryContracts;

namespace Services
{
    public class ChaptersAdderService : IChaptersAdderService
    {
        private readonly ITestimonialsRepository _testimonialsRepository;
        private readonly IImageStorageService _imageStorageService;

        public ChaptersAdderService(
            ITestimonialsRepository testimonialsRepository,
            IImageStorageService imageStorageService
        )
        {
            _testimonialsRepository = testimonialsRepository;
            _imageStorageService = imageStorageService;
        }

        public async Task<ItemResult<TestimonialResult>> AddTestimonial(TestimonialRequest testimonialAddRequest)
        {
            var testimonial = new Testimonial();

            testimonial.PositionAndCompany = testimonialAddRequest.PositionAndCompany;
            testimonial.Content = testimonialAddRequest.Content;
            testimonial.Order = testimonialAddRequest.Order;
            testimonial.IsActive = testimonialAddRequest.IsActive;

            await _testimonialsRepository.AddTestimonial(testimonial);

            return new ItemResult<TestimonialResult>(new TestimonialResult(testimonial.Id, testimonial.PositionAndCompany, testimonial.Content, testimonial.ImageUrl, testimonial.Order, testimonial.IsActive));
        }
    }
}