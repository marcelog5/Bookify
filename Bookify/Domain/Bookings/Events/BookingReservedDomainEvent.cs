using Domain.Abstracts;

namespace Domain.Bookings.Events
{
    public sealed record BookingReservedDomainEvent(Guid BookingId) : IDomainEvent;
}