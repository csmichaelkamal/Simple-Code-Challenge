// This code is private to MAERSK
// Copyright 2022

using MAERSK.ServiceDelivery.CodeChallenge.APIs.Models;
using System.Collections.Generic;

namespace MAERSK.ServiceDelivery.CodeChallenge.APIs.Services
{
    public interface ICurrencyService
    {
        List<Currency> GetSupportedCurrencies();
    }
}
