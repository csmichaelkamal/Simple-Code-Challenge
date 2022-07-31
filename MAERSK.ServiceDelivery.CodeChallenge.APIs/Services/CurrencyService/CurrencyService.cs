// This code is private to MAERSK
// Copyright 2022

using MAERSK.ServiceDelivery.CodeChallenge.APIs.Models;
using System.Collections.Generic;
using System.Linq;

namespace MAERSK.ServiceDelivery.CodeChallenge.APIs.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly ServiceDeliveryDbContext _serviceDeliveryDbContext;

        public CurrencyService(ServiceDeliveryDbContext serviceDeliveryDbContext)
        {
            _serviceDeliveryDbContext = serviceDeliveryDbContext;
        }

        public List<Currency> GetSupportedCurrencies()
        {
            // We should appy pagination here, if we are supporting many currencies now or in the future
            return _serviceDeliveryDbContext.Currencies
                .Where(currency => !string.IsNullOrEmpty(currency.Name))
                .ToList();
        }
    }
}
