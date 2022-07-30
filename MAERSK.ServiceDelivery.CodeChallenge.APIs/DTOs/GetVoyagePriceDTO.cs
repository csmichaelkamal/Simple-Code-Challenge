// This code is private to MAERSK
// Copyright 2022

using MAERSK.ServiceDelivery.CodeChallenge.APIs.Models;

namespace MAERSK.ServiceDelivery.CodeChallenge.APIs.DTOs
{
    public class GetVoyagePriceDTO
    {
        public string VoyageCode { get; set; }
        public decimal Price { get; set; }
        public Currency Currency { get; set; }
    }
}
