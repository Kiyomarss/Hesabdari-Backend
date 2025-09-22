using System;
using System.ComponentModel.DataAnnotations;
using ContactsManager.Core.Domain.IdentityEntities;

namespace Hesabdari_Core.Domain.Entities;

public class UserCourse
{
    [Key]
    public int Id { get; set; }

    public Guid UserId { get; set; }
    public ApplicationUser User { get; set; } = null!;

    public int CourseId { get; set; }
    public Course Course { get; set; } = null!;
}