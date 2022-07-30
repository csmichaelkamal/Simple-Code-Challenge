// This code is private to MAERSK
// Copyright 2022

using MAERSK.ServiceDelivery.CodeChallenge.APIs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MAERSK.ServiceDelivery.CodeChallenge.APIs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CurrenciesController : ControllerBase
    {
        private readonly ILogger<CurrenciesController> _logger;

        public CurrenciesController(ILogger<CurrenciesController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Get list of available currencies
        /// Currently, our application supports 3 currencies
        /// We will update the application to support more currencies as our business continue to grow
        /// If the 
        /// </summary>
        /// <returns>List of available currencies used in our system</returns>
        [HttpGet("Available")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAvailableCurrencies()
        {
            _logger.LogInformation($"{nameof(GetAvailableCurrencies)} executed at: {DateTime.Now}");

            var availableCurrencies = new List<Currency>
            {
                new Currency { Name = "USD" },
                new Currency { Name = "EUR" },
                new Currency { Name = "DKK" },
                new Currency { Name = "GBP" }
            };

            return Ok(availableCurrencies);
        }
    }
}
