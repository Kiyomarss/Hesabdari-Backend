namespace ServiceContracts
{
    public interface IChaptersDeleterService
    {
        Task DeleteChapter(int chapterId);
    }    
}
