using Application.Abstracts.Messaging;

namespace Application.Apartments.SearchApartments
{
    public sealed record SearchApartmentsQuery(
        DateOnly StartDate, 
        DateOnly EndDate) : IQuery<IReadOnlyList<ApartmentResponse>>
    {
    }
}
