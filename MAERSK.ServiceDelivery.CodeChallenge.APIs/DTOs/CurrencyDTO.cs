// This code is private to MAERSK
// Copyright 2022

using System.ComponentModel.DataAnnotations;

namespace MAERSK.ServiceDelivery.CodeChallenge.APIs.DTOs
{
    public class CurrencyDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}
