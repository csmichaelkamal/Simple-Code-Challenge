// This code is private to MAERSK
// Copyright 2022

using Newtonsoft.Json;

namespace MAERSK.ServiceDelivery.CodeChallenge.APIs.Responses.VoyagePrices
{
    public class GetAveragePriceResponse
    {
        [JsonProperty("Voyage Code")]
        public string VoyageCode { get; set; }

        [JsonProperty("Average Price")]
        public decimal AveragePrice { get; set; }
    }
}
