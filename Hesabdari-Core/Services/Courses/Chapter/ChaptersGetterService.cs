using ServiceContracts;
using Hesabdari_Core.DTO;
using RepositoryContracts;

namespace Services
{
    public class ChaptersGetterService : IChaptersGetterService
    {
        private readonly IChaptersRepository _chaptersRepository;

        public ChaptersGetterService(IChaptersRepository chaptersRepository)
        {
            _chaptersRepository = chaptersRepository;
        }
    }
}