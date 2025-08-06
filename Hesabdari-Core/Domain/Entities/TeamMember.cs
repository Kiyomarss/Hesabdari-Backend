using System.ComponentModel.DataAnnotations;

namespace Hesabdari_Core.Domain.Entities;

public class TeamMember
{
    [Key] public int Id { get; set; }

    public string FullName { get; set; }

    public string Position { get; set; }

    public string Bio { get; set; }

    public string? ImageUrl { get; set; }

    public int Order { get; set; }

    public bool IsActive { get; set; }
}