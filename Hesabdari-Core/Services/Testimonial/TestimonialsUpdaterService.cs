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

            var testimonial = await _testimonialsRepository.FindTestimonialById((int)testimonialUpdateRequest.Id);

            if (testimonial == null)
                throw new InvalidOperationException("Testimonial with the given ID does not exist.");

            testimonial.PositionAndCompany = testimonialUpdateRequest.PositionAndCompany;
            testimonial.Content = testimonialUpdateRequest.Content;
            testimonial.Order = testimonialUpdateRequest.Order;
            testimonial.IsActive = testimonialUpdateRequest.IsActive;

            await _testimonialsRepository.UpdateTestimonial();

            return new ItemResult<TestimonialResult>(new TestimonialResult(testimonial.Id, testimonial.PositionAndCompany, testimonial.Content, testimonial.ImageUrl, testimonial.Order, testimonial.IsActive));
        }

        public async Task RemoveImageTestimonial(int testimonialId)
        {
            var testimonial = await _testimonialsRepository.FindTestimonialById(testimonialId);

            if (testimonial == null)
                throw new KeyNotFoundException($"testimonial with ID {testimonialId} does not exist.");

            await _imageStorageService.DeleteOldImagesAsync(testimonial.ImageUrl);

            testimonial.ImageUrl = null;

            await _testimonialsRepository.UpdateTestimonial();
        }
        
        public async Task<ItemResult<string>> UpdateImageTestimonial(FileUploadDto dto)
        {
            var testimonial = await _testimonialsRepository.FindTestimonialById(dto.Id);

            if (testimonial == null)
                throw new KeyNotFoundException($"testimonial with ID {dto.Id} does not exist.");

            await _imageStorageService.DeleteOldImagesAsync(testimonial.ImageUrl);

            testimonial.ImageUrl = await _imageStorageService.SaveImageAsync(dto.File);

            await _testimonialsRepository.UpdateTestimonial();

            return new ItemResult<string>(testimonial.ImageUrl);
        }
    }
}