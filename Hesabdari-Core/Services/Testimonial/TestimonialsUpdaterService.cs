using Hesabdari_Core.DTO;
using Hesabdari_Core.DTO.Base;
using Hesabdari_Core.ServiceContracts.Storage;
using ServiceContracts;
using RepositoryContracts;

namespace Services
{
    public class TestimonialsUpdaterService : ITestimonialsUpdaterService
    {
        private readonly ITestimonialsRepository _testimonialsRepository;
        private readonly IImageStorageService _imageStorageService;

        public TestimonialsUpdaterService(
            ITestimonialsRepository testimonialRepository,
            IImageStorageService imageStorageService)
        {
            _testimonialsRepository = testimonialRepository;
            _imageStorageService = imageStorageService;
        }

        public async Task<ItemResult<TestimonialResult>> UpdateTestimonial(TestimonialRequest testimonialUpdateRequest)
        {
            if (testimonialUpdateRequest == null)
                throw new InvalidOperationException("Testimonial with the given ID does not exist.");

            var testimonial = await _testimonialsRepository.FindTestimonialById(testimonialUpdateRequest.Id);

            if (testimonial == null)
                throw new InvalidOperationException("Testimonial with the given ID does not exist.");

            if (testimonialUpdateRequest.Image != null)
            {
                await _imageStorageService.DeleteOldImagesAsync(testimonial.ImageUrl);

                testimonial.ImageUrl = await _imageStorageService.SaveImageAsync(testimonialUpdateRequest.Image);
            }

            testimonial.PositionAndCompany = testimonialUpdateRequest.PositionAndCompany;
            testimonial.Content = testimonialUpdateRequest.Content;

            await _testimonialsRepository.UpdateTestimonial();

            return new ItemResult<TestimonialResult>(new TestimonialResult(testimonial.Id, testimonial.PositionAndCompany, testimonial.Content, testimonial.ImageUrl, testimonial.Order, testimonial.IsActive));
        }

        public async Task DeleteImageTestimonial(int testimonialId)
        {
            var testimonial = await _testimonialsRepository.FindTestimonialById(testimonialId);

            if (testimonial == null)
                throw new KeyNotFoundException($"testimonial with ID {testimonialId} does not exist.");

            await _imageStorageService.DeleteOldImagesAsync(testimonial.ImageUrl);

            testimonial.ImageUrl = null;

            await _testimonialsRepository.UpdateTestimonial();
        }
    }
}