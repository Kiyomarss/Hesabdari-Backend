namespace Hesabdari_Core.DTO;

public class LessonRequest
{
    public int? Id { get; set; }
    
    public string Title { get; set; }
    
    public int Order { get; set; }
    
    public bool IsFree { get; set; }
}