using Hesabdari_Core.Domain.Entities;
using Hesabdari_Core.DTO;
using Hesabdari_Core.ServiceContracts.Storage;
using ServiceContracts;
using RepositoryContracts;

namespace Services
{
    public class ChaptersAdderService : IChaptersAdderService
    {
        private readonly IChaptersRepository _testimonialsRepository;

        public ChaptersAdderService(
            IChaptersRepository testimonialsRepository
        )
        {
            _testimonialsRepository = testimonialsRepository;
        }

        public async Task<ItemResult<ChapterResult>> AddChapter(ChapterRequest chapterAddRequest)
        {
            var chapter = new Chapter();

            chapter.Title = chapterAddRequest.Title;
            chapter.Order = chapterAddRequest.Order;

            await _testimonialsRepository.AddChapter(chapter);

            return new ItemResult<ChapterResult>(new ChapterResult(chapter.Id, chapter.Title, chapter.Order));
        }
    }
}