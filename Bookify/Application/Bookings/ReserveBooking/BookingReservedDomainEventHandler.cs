﻿using Application.Abstracts.Email;
using Domain.Bookings;
using Domain.Bookings.Events;
using Domain.Users;
using MediatR;

namespace Application.Bookings.ReserveBooking
{
    internal sealed class BookingReservedDomainEventHandler : INotificationHandler<BookingReservedDomainEvent>
    {
        private readonly IbookingRepository _bookingRepository;
        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailService;

        public BookingReservedDomainEventHandler(
            IbookingRepository bookingRepository, 
            IUserRepository userRepository, 
            IEmailService emailService)
        {
            _bookingRepository = bookingRepository;
            _userRepository = userRepository;
            _emailService = emailService;
        }

        public async Task Handle(BookingReservedDomainEvent notification, CancellationToken cancellationToken)
        {
            var booking = await _bookingRepository.GetByIdAsync(notification.BookingId, cancellationToken);

            if (booking is null)
            {
                return;
            }

            var user = await _userRepository.GetByIdAsync(booking.UserId, cancellationToken);

            if (user is null)
            {
                return;
            }

            await _emailService.SendAsync(
                user.Email, 
                "Booking reserved!", 
                "You have 10 minutes to confirm this booking");
        }
    }
}
