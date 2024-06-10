using Domain.Abstracts;

namespace Domain.Bookings.Events
{
    public sealed record BookingCompletedDomainEvent(Guid BookingId) : IDomainEvent;
}