// This code is private to MAERSK
// Copyright 2022

using MAERSK.ServiceDelivery.CodeChallenge.APIs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace MAERSK.ServiceDelivery.CodeChallenge.APIs.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class VoyagePricesController : ControllerBase
    {
        private readonly ILogger<VoyagePricesController> _logger;

        public VoyagePricesController(ILogger<VoyagePricesController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Update container price for a given voyage
        /// </summary>
        /// <param name="voyageCode"></param>
        /// <param name="price"></param>
        /// <param name="currency"></param>
        /// <param name="timestamp"></param>
        /// <returns></returns>
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdatePrice(string voyageCode, decimal price,
            Currency currency, DateTimeOffset timestamp)
        {
            _logger.LogInformation($"{nameof(UpdatePrice)} executed at: {DateTime.Now}");
            return Ok(voyageCode);
        }

        /// <summary>
        /// Get the average (in a given currency) of the last 10 prices for containers booked on a given voyage.
        /// If the 
        /// </summary>
        /// <param name="voyageCode"></param>
        /// <param name="currencyName"></param>
        /// <returns>Avergae price of the last 10 prices for containers</returns>
        [HttpGet("Average/{voyageCode}/{currency}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAveragePrice(string voyageCode, string currencyName)
        {
            _logger.LogInformation($"{nameof(GetAveragePrice)} executed at: {DateTime.Now}");
            return Ok(voyageCode);
        }
    }
}
