using Domain.Shared;

namespace Domain.Bookings
{
    public record PricingDetails(
        Money PriceForPeriod,
        Money CleaningFee,
        Money AmenitiesUpcharge,
        Money TotalPrice);
}