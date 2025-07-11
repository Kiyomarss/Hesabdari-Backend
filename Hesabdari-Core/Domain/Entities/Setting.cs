using System.ComponentModel.DataAnnotations;

namespace Hesabdari_Core.Domain.Entities;

public class Setting
{
    [Key]
    public Guid Id { get; set; }
    
    public int MinBookingLength { get; set; }
    
    public int MaxBookingLength { get; set; }
    
    public int MaxGuestsPerBooking { get; set; }
    
    public int BreakfastPrice { get; set; }
    
    public DateTime CreateAt { get; set; }
}