namespace Hesabdari_Core.DTO;

public class CourseRequest
{
    public int? Id { get; set; }
    
    public string Title { get; set; }

    public string ShortDescription { get; set; }

    public string FullDescription { get; set; }

    public long Price { get; set; }
    
    public int Order { get; set; }
    
    public bool IsActive { get; set; }
}