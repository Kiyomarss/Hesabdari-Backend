using Hesabdari_Core.DTO;

namespace ServiceContracts
{
    public interface IChaptersAdderService
    {
        Task<ItemResult<ChapterResult>> AddChapter(ChapterRequest chapterAddRequest);
    }
}
