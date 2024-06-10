﻿using Domain.Abstracts;
using Domain.Bookings.Events;
using Domain.Shared;

namespace Domain.Bookings
{
    public sealed class Booking : Entity
    {
        private Booking(
        Guid id,
        Guid apartmentId,
        Guid userId,
        DateRange duration,
        Money pricePerPeriod,
        Money cleaningFee,
        Money amenitiesUpcharge,
        Money totalPrice,
        BookingStatus status,
        DateTime createdOnUtc
        ) : base(id)
        {
            Id = id;
            ApartmentId = apartmentId;
            UserId = userId;
            Duration = duration;
            PricePerPeriod = pricePerPeriod;
            CleaningFee = cleaningFee;
            AmenitiesUpcharge = amenitiesUpcharge;
            TotalPrice = totalPrice;
            Status = status;
            CreatedOnUtc = createdOnUtc;
        }

        public Guid ApartmentId { get; private set; }
        public Guid UserId { get; private set; }
        public DateRange Duration { get; private set; }
        public Money PricePerPeriod { get; private set; }
        public Money CleaningFee { get; private set; }
        public Money AmenitiesUpcharge { get; private set; }
        public Money TotalPrice { get; private set; }
        public BookingStatus Status { get; private set; }
        public DateTime CreatedOnUtc { get; private set; }
        public DateTime? ConfirmedOnUtc { get; private set; }
        public DateTime? RejectedOnUtc { get; private set; }
        public DateTime? CompletedOnUtc { get; private set; }
        public DateTime? CancelledOnUtc { get; private set; }
    
        public static Booking Reserve(
            Guid apartmentId,
            Guid userId,
            DateRange duration,
            DateTime utcNow,
            PricingDetails pricingDetails)
        {
            Booking booking = new Booking(
                Guid.NewGuid(),
                apartmentId,
                userId,
                duration,
                pricingDetails.PriceForPeriod,
                pricingDetails.CleaningFee,
                pricingDetails.AmenitiesUpcharge,
                pricingDetails.TotalPrice,
                BookingStatus.Reserved,
                utcNow);

            booking.RaiseDomainEvent(new BookingReservedDomainEvent(booking.Id));

            return booking;
        }
    }
}
