using Domain.Abstracts;
using Domain.Users.Events;

namespace Domain.Users
{
    public sealed class User : Entity
    {
        private User (
            Guid id, 
            FirstName firstName, 
            LastName lastName, 
            Email email)
            : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        private User()
        {
        }

        public FirstName FirstName { get; private set; }
        public LastName LastName { get; private set; }
        public Email Email { get; private set; }
    
        // Static Factory Pattern
        public static User Create(FirstName firstName, LastName lastName, Email email)
        {
            User user = new User(Guid.NewGuid(), firstName, lastName, email);
        
            // Add Domain Event
            user.RaiseDomainEvent(new UserCreatedDomainEvent(user.Id));

            return user;
        }
    }
}
