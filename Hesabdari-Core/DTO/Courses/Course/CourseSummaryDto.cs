namespace Hesabdari_Core.DTO;

public class CourseSummaryDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string ShortDescription { get; set; } = null!;
    public long Price { get; set; }
    public string ImageUrl { get; set; } = null!;
}