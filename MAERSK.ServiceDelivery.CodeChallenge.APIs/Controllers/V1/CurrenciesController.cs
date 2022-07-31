// This code is private to MAERSK
// Copyright 2022

using MAERSK.ServiceDelivery.CodeChallenge.APIs.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace MAERSK.ServiceDelivery.CodeChallenge.APIs.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CurrenciesController : ControllerBase
    {
        private readonly ILogger<CurrenciesController> _logger;
        private readonly ICurrencyService _currencyService;

        public CurrenciesController(ILogger<CurrenciesController> logger,
            ICurrencyService currencyService)
        {
            _logger = logger;
            _currencyService = currencyService;
        }

        /// <summary>
        /// Get list of supported currencies
        /// Currently, our application supports 4 currencies
        /// We will update the application to support more currencies as our business continue to grows
        /// </summary>
        /// <returns>List of supported currencies used in our system</returns>
        [HttpGet("Supported")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult GetSupportedCurrencies()
        {
            _logger.LogInformation($"{nameof(GetSupportedCurrencies)}: executed at: {DateTime.Now}");

            var availableCurrencies = _currencyService.GetSupportedCurrencies();

            if (availableCurrencies != null && availableCurrencies.Count > 0)
            {
                _logger.LogInformation($"{nameof(GetSupportedCurrencies)}: " +
                    $"{(nameof(availableCurrencies))} count: {availableCurrencies.Count}");
                return Ok(availableCurrencies);
            }

            _logger.LogError($"{nameof(GetSupportedCurrencies)}: " +
                    $"{(nameof(availableCurrencies))} not found");

            return NotFound("No Available Currencies Supported");
        }
    }
}
