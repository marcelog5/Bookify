using Domain.Abstracts;

namespace Domain.Bookings.Events
{
    public sealed record BookingCancelledDomainEvent(Guid BookingId) : IDomainEvent;
}