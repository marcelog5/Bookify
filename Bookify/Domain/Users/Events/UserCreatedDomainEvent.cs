using Domain.Abstracts;

namespace Domain.Users.Events
{
    public sealed record UserCreatedDomainEvent (Guid userId) : IDomainEvent;
}
