namespace Application.Abstracts.Clock
{
    public interface IDateTimeProvider
    {
        DateTime UtcNow { get; }
    }
}
