﻿using FluentValidation;

namespace Application.Bookings.ReserveBooking
{
    public class ReserveBookingCommandValidator : AbstractValidator<ReserveBookingCommand>
    {
        public ReserveBookingCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.ApartmentId).NotEmpty();
            RuleFor(x => x.StartDate).LessThan(c => c.EndDate);
        }
    }
}
