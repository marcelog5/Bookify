using Domain.Apartments;
using Domain.Shared;

namespace Domain.Bookings
{
    public class PricingService
    {
        public PricingDetails CalculatePrice(Apartment apartment, DateRange period)
        {
            Currency currency = apartment.Price.Currency;
            Money priceForPeriod = new Money(
                apartment.Price.Amount * period.LengthInDays,
                currency);

            decimal percentageUpcharge = 0;
            foreach (var amenity in apartment.Amenities)
            {
                percentageUpcharge += amenity switch
                {
                    Amenity.GardenView or Amenity.MountainView => 0.05m,
                    Amenity.AirConditioning => 0.01m,
                    Amenity.Parking => 0.01m,
                    _ => 0
                };
            }

            Money amenitiesUpcharge = Money.Zero(currency);
            if (percentageUpcharge > 0)
            {
                amenitiesUpcharge = new Money(
                    priceForPeriod.Amount * percentageUpcharge,
                    currency);
            }

            Money totalPrice = Money.Zero(currency);

            totalPrice += priceForPeriod;

            if (!apartment.CleaningFee.IsZero()) 
            { 
                totalPrice += apartment.CleaningFee;
            }

            totalPrice += amenitiesUpcharge;

            return new PricingDetails(
                priceForPeriod,
                apartment.CleaningFee,
                amenitiesUpcharge,
                totalPrice
            );
        }

    }
}
