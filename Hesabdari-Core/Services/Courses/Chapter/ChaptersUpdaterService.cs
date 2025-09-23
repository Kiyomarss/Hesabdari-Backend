using Hesabdari_Core.DTO;
using Hesabdari_Core.DTO.Base;
using Hesabdari_Core.ServiceContracts.Storage;
using ServiceContracts;
using RepositoryContracts;

namespace Services
{
    public class ChaptersUpdaterService : IChaptersUpdaterService
    {
        private readonly IChaptersRepository _chaptersRepository;

        public ChaptersUpdaterService(IChaptersRepository chapterRepository)
        {
            _chaptersRepository = chapterRepository;
        }

        public async Task<ItemResult<ChapterResult>> UpdateChapter(ChapterRequest chapterUpdateRequest)
        {
            if (chapterUpdateRequest == null)
                throw new InvalidOperationException("Chapter with the given ID does not exist.");

            var chapter = await _chaptersRepository.FindChapterById((int)chapterUpdateRequest.Id);

            if (chapter == null)
                throw new InvalidOperationException("Chapter with the given ID does not exist.");

            chapter.Title = chapterUpdateRequest.Title;
            chapter.Order = chapterUpdateRequest.Order;

            await _chaptersRepository.UpdateChapter();

            return new ItemResult<ChapterResult>(new ChapterResult(chapter.Id, chapter.Title, chapter.Order));
        }
    }
}