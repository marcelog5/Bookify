namespace Domain.Shared
{
    public record Money(decimal Amount, Currency Currency)
    {
        public static Money operator +(Money m1, Money m2)
        {
            if (m1.Currency != m2.Currency)
            {
                throw new ApplicationException("Cannot sum money with different currencies");
            }

            return new Money(m1.Amount + m2.Amount, m1.Currency);
        }

        public static Money Zero() => new Money(0, Currency.None);

        public static Money Zero(Currency currency) => new Money(0, currency);

        public bool IsZero() => this == Zero(Currency);
    }
}
