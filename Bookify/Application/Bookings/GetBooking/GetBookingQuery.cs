using Application.Abstracts.Messaging;

namespace Application.Bookings.GetBooking
{
    public sealed record GetBookingQuery(Guid BookingId) : IQuery<BookingResponse>;
}
