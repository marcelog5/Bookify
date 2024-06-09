﻿namespace Domain.Apartments
{
    public record Currency
    {
        internal static readonly Currency None = new(string.Empty);
        public static readonly Currency Brl = new("BRL");
        public static readonly Currency Usd = new("USD");
        public static readonly Currency Eur = new("EUR");

        private Currency(string code) => Code = code;

        public string Code { get; init; }

        public static Currency FromCode(string code)
        {
            return All.FirstOrDefault(x => x.Code == code) ??
                throw new ApplicationException($"The currency code is invalid");
        }

        public static readonly IReadOnlyCollection<Currency> All = new[] 
        { 
            Brl, 
            Usd, 
            Eur 
        };
    }
}
