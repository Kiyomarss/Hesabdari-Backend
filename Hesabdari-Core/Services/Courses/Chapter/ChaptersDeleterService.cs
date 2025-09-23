using Hesabdari_Core.ServiceContracts.Storage;
using ServiceContracts;
using RepositoryContracts;

namespace Services
{
    public class ChaptersDeleterService : IChaptersDeleterService
    {
        private readonly IChaptersRepository _chaptersRepository;

        public ChaptersDeleterService(IChaptersRepository chaptersRepository)
        {
            _chaptersRepository = chaptersRepository;
        }

        public async Task DeleteChapter(int chapterId)
        {
            var chapter = await _chaptersRepository.FindChapterById(chapterId);

            if (chapter == null)
                throw new KeyNotFoundException($"chapter with ID {chapterId} does not exist.");
            
            await _chaptersRepository.DeleteChapter(chapterId);
        }
    }
}