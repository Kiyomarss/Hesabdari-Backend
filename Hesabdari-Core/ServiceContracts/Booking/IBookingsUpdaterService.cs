using Hesabdari_Core.Domain.Entities;
using Hesabdari_Core.DTO;
using Microsoft.AspNetCore.JsonPatch;

namespace ServiceContracts
{
    public interface IBookingsUpdaterService
    {
        Task<BookingResult> UpdateBooking(Guid bookingId, JsonPatchDocument<Booking> patchDoc);
    };
}