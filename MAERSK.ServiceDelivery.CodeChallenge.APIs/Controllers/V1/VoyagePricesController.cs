// This code is private to MAERSK
// Copyright 2022

#region Using

using MAERSK.ServiceDelivery.CodeChallenge.APIs.DTOs;
using MAERSK.ServiceDelivery.CodeChallenge.APIs.Requests.VoyagePrices;
using MAERSK.ServiceDelivery.CodeChallenge.APIs.Responses.VoyagePrices;
using MAERSK.ServiceDelivery.CodeChallenge.APIs.Services.VoyagePriceService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

#endregion

namespace MAERSK.ServiceDelivery.CodeChallenge.APIs.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class VoyagePricesController : ControllerBase
    {
        #region Members

        private readonly IVoyagePriceService _voyagePriceService;
        private readonly ILogger<VoyagePricesController> _logger;

        #endregion

        #region Ctor

        public VoyagePricesController(
            IVoyagePriceService voyagePriceService,
            ILogger<VoyagePricesController> logger)
        {
            _voyagePriceService = voyagePriceService;
            _logger = logger;
        }

        #endregion

        #region Public EndPoints

        /// <summary>
        /// Update container price for a given voyage
        /// </summary>
        /// <param name="voyageCode"></param>
        /// <param name="price"></param>
        /// <param name="currency"></param>
        /// <param name="timestamp"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdatePrice(UpdatePriceRequest request)
        {
            _logger.LogInformation($"{nameof(UpdatePrice)} executed at: {DateTime.Now}");

            await _voyagePriceService.UpdatePrice(new UpdateVoyagePriceDTO
            {
                Currency = request.Currency,
                Timestamp = request.Timestamp,
                VoyageCode = request.VoyageCode
            }).ConfigureAwait(false);

            return NoContent();
        }

        /// <summary>
        /// Get the average (in a given currency) of the last 10 prices for containers booked on a given voyage.
        /// If the 
        /// </summary>
        /// <param name="voyageCode"></param>
        /// <param name="currencyName"></param>
        /// <returns>Avergae price of the last 10 prices for containers</returns>
        [HttpGet("Average/{voyageCode}/{currencyName}")]
        [Produces(typeof(GetAveragePriceResponse))]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAveragePrice(string voyageCode, string currencyName)
        {
            _logger.LogInformation($"{nameof(GetAveragePrice)} executed at: {DateTime.Now}");

            var averagePrice = await _voyagePriceService.
                GetAveragePrice(new GetVoyagePriceDTO
                {
                    CurrencyName = currencyName,
                    VoyageCode = voyageCode
                })
                .ConfigureAwait(false);

            if (averagePrice is null)
            {
                return NotFound();
            }

            return Ok(averagePrice);
        }

        #endregion
    }
}
