using Hesabdari_Core.ServiceContracts.Storage;
using ServiceContracts;
using RepositoryContracts;

namespace Services
{
    public class UserCoursesDeleterService : IUserCoursesDeleterService
    {
        private readonly ITestimonialsRepository _testimonialsRepository;
        private readonly IImageStorageService _imageStorageService;

        //constructor
        public UserCoursesDeleterService(
            ITestimonialsRepository testimonialsRepository,
            IImageStorageService imageStorageService
        )
        {
            _testimonialsRepository = testimonialsRepository;
            _imageStorageService = imageStorageService;
        }

        public async Task DeleteTestimonial(int testimonialId)
        {
            var testimonial = await _testimonialsRepository.FindTestimonialById(testimonialId);

            if (testimonial == null)
                throw new KeyNotFoundException($"testimonial with ID {testimonialId} does not exist.");

            await _imageStorageService.DeleteOldImagesAsync(testimonial.ImageUrl);

            await _testimonialsRepository.DeleteTestimonial(testimonialId);
        }
    }
}