using Hesabdari_Core.Domain.Entities;
using Hesabdari_Core.DTO;
using Hesabdari_Core.DTO.Base;
using Hesabdari_Core.ServiceContracts;
using Hesabdari_Core.ServiceContracts.Storage;
using Hesabdari_Core.Utils;
using ServiceContracts;
using RepositoryContracts;
using Microsoft.Extensions.Logging;

namespace Services
{
    public class TestimonialsAdderService : ITestimonialsAdderService
    {
        private readonly ITestimonialsRepository _testimonialsRepository;
        private readonly IImageStorageService _imageStorageService;

        public TestimonialsAdderService(
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

            if (testimonialAddRequest.Image != null)
            {
                testimonial.ImageUrl = await _imageStorageService.SaveImageAsync(testimonialAddRequest.Image);
            }

            testimonial.PositionAndCompany = testimonialAddRequest.PositionAndCompany;
            testimonial.Content = testimonialAddRequest.Content;

            var slide = await _testimonialsRepository.AddTestimonial(testimonial);

            return new ItemResult<TestimonialResult>(new TestimonialResult(slide.Id, slide.PositionAndCompany, slide.Content, slide.ImageUrl, slide.Order, slide.IsActive));
        }
    }
}