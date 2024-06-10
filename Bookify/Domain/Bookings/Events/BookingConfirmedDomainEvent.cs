using Domain.Abstracts;

namespace Domain.Bookings.Events
{
    public sealed record BookingConfirmedDomainEvent(Guid BookingId) : IDomainEvent;
}