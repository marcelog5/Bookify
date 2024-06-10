using Domain.Abstracts;

namespace Domain.Bookings.Events
{
    public sealed record BookingRejectedDomainEvent(Guid BookingId) : IDomainEvent;
}