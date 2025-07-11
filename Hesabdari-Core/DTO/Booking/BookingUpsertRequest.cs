using Hesabdari_Core.Domain.Entities;
using Hesabdari_Core.Domain.Entities;

namespace Hesabdari_Core.DTO;

public class BookingUpsertRequest
{
    public Guid Id { get; set; }
    
    public DateTime StartDate { get; set; }
    
    public DateTime EndDate { get; set; }
    
    public int NumNights { get; set; }
    
    public int NumGuests { get; set; }
    
    public int HeroSlidePrice { get; set; }
    
    public int ExtrasPrice { get; set; }
    
    public int TotalPrice { get; set; }
    
    public string Status { get; set; }
    
    public bool HasBreakfast { get; set; }
    
    public bool IsPaid { get; set; }
    
    public string Observations { get; set; }
    
   
    public Guid GuestId { get; set; }

    public DateTime CreateAt { get; set; }
    
    public Booking Tobooking()
    {
        return new Booking
        {
            StartDate = StartDate,
            EndDate = EndDate,
            NumNights = NumNights,
            NumGuests = NumGuests,
            HeroSlidePrice = HeroSlidePrice,
            ExtrasPrice = ExtrasPrice,
            TotalPrice = TotalPrice,
            Status = Status,
            HasBreakfast = HasBreakfast,
            IsPaid = IsPaid,
            Observations = Observations,
            GuestId = GuestId,
            CreateAt = CreateAt,
        };
    }
}