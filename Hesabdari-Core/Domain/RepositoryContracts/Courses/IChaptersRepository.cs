using Hesabdari_Core.Domain.Entities;
using Hesabdari_Core.DTO;

namespace RepositoryContracts;

public interface IChaptersRepository
{
    Task<Chapter> AddChapter(Chapter chapter);
    
    Task UpdateChapter();
    
    Task<bool> DeleteChapter(int chapterId);
}