using MAERSK.ServiceDelivery.CodeChallenge.APIs.Models;
using System.Collections.Generic;

namespace MAERSK.ServiceDelivery.CodeChallenge.UnitTests.Helpers
{
    public class CurrencyHelper
    {
        public static List<Currency> PopulateData()
        {
            return new List<Currency>
            {
                new Currency { Id = 1, Name = "USD"},
                new Currency { Id = 2, Name = "EUR"},
                new Currency { Id = 3, Name = "DKK"},
                new Currency { Id = 4, Name = "GBP"}
            };
        }
    }
}
