// This code is private to MAERSK
// Copyright 2022

using MAERSK.ServiceDelivery.CodeChallenge.APIs.DTOs;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace MAERSK.ServiceDelivery.CodeChallenge.APIs.Requests.VoyagePrices
{
    public class UpdatePriceRequest
    {
        [Required]
        [JsonProperty("Voyage Code")]
        public string VoyageCode { get; set; }

        [Required]
        public CurrencyDTO Currency { get; set; }

        [Required]
        public DateTimeOffset Timestamp { get; set; }
    }
}
