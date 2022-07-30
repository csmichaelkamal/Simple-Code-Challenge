// This code is private to MAERSK
// Copyright 2022

using System.ComponentModel.DataAnnotations;

namespace MAERSK.ServiceDelivery.CodeChallenge.APIs.Models
{
    /// <summary>
    /// Hold the currency data
    /// </summary>
    public class Currency : EntityBase<int>
    {
        /// <summary>
        /// The Name of the currency
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Cannot be Empty")]
        [StringLength(100, ErrorMessage = "{0} Maximum length is {1}")]
        public string Name { get; set; }
    }
}
