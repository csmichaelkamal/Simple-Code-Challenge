// This code is private to MAERSK
// Copyright 2022

using System;

namespace MAERSK.ServiceDelivery.CodeChallenge.APIs.DTOs
{
    public class UpdateVoyagePriceDTO
    {
        public string VoyageCode { get; set; }
        
        public CurrencyDTO Currency { get; set; }
        
        public DateTimeOffset Timestamp { get; set; }
    }
}
