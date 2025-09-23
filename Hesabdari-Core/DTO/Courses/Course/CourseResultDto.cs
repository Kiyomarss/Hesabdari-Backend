namespace Hesabdari_Core.DTO;

public class CourseResultDto
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string ShortDescription { get; set; }

    public string FullDescription { get; set; }

    public long Price { get; set; }
    
    public string IntroVideoUrl { get; set; }

    public List<ChapterResultDto> Chapters { get; set; } = new();
}

public class ChapterResultDto
{
    public int Id { get; set; }
    
    public string Title { get; set; }

    public int Order { get; set; }

    public List<LessonResultDto> Lessons { get; set; } = new();
}

public class LessonResultDto
{
    public int Id { get; set; }
    
    public string Title { get; set; }
    
    public int Order { get; set; }

    public string VideoUrl { get; set; }
    
    public string Duration { get; set; }
}