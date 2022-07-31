// This code is private to MAERSK
// Copyright 2022

using System;
using System.ComponentModel.DataAnnotations;

namespace MAERSK.ServiceDelivery.CodeChallenge.APIs.Models
{
    /// <summary>
    /// Hold the voyage price data
    /// </summary>
    public class VoyagePrice : EntityBase<Guid>
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Cannot be empty")]
        [StringLength(100, ErrorMessage = "{0} maximum length is {1}")]
        public string VoyageCode { get; set; }


        public decimal Price { get; set; }
        

        public int CurrencyId { get; set; }
        

        public DateTimeOffset Timestamp { get; set; }
    }
}
