// This code is private to MAERSK
// Copyright 2022

using MAERSK.ServiceDelivery.CodeChallenge.APIs.DTOs;
using MAERSK.ServiceDelivery.CodeChallenge.APIs.Models;
using MAERSK.ServiceDelivery.CodeChallenge.APIs.Responses.VoyagePrices;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MAERSK.ServiceDelivery.CodeChallenge.APIs.Services.VoyagePriceService
{
    public class VoyagePriceService : IVoyagePriceService
    {
        private const int Number_Of_Voyages = 10;
        private readonly ServiceDeliveryDbContext _serviceDeliveryDbContext;
        private readonly ILogger<VoyagePriceService> _logger;

        public VoyagePriceService(ServiceDeliveryDbContext serviceDeliveryDbContext,
            ILogger<VoyagePriceService> logger)
        {
            _serviceDeliveryDbContext = serviceDeliveryDbContext;
            _logger = logger;
        }

        public async Task<GetAveragePriceResponse> GetAveragePrice(GetVoyagePriceDTO getAverageVoyagePriceDTO)
        {
            #region Validation

            if (!IsSupportedCurrency(getAverageVoyagePriceDTO.CurrencyName))
            {
                _logger.LogError($"{nameof(GetAveragePrice)}: Not Supported Currency {getAverageVoyagePriceDTO.CurrencyName}");
                return null;
            }

            if (!IsVoyageExists(getAverageVoyagePriceDTO.VoyageCode))
            {
                _logger.LogError($"{nameof(GetAveragePrice)}: No voyage found: {getAverageVoyagePriceDTO.VoyageCode}");
                return null;
            }

            #endregion

            var voyageLastPrices = _serviceDeliveryDbContext.VoyagePrices
                .Where(voyage => string.Equals(voyage.VoyageCode, getAverageVoyagePriceDTO.VoyageCode, StringComparison.InvariantCultureIgnoreCase))
                .OrderByDescending(voyage => voyage.Timestamp)
                .Take(Number_Of_Voyages)
                .ToList();

            if (voyageLastPrices is null || voyageLastPrices.Count < 1)
            {
                _logger.LogWarning($"{nameof(GetAveragePrice)}: no voyage prices for {getAverageVoyagePriceDTO.VoyageCode}");
                return null;
            }

            return new GetAveragePriceResponse
            {
                AveragePrice = voyageLastPrices.Average(voyagePrice => voyagePrice.Price),
                VoyageCode = getAverageVoyagePriceDTO.VoyageCode
            };
        }

        public async Task UpdatePrice(UpdateVoyagePriceDTO voyagePriceDTO)
        {
            _logger.LogInformation($"{nameof(UpdatePrice)}: Updating container price for {voyagePriceDTO.VoyageCode}");

            #region Validation

            if (!IsSupportedCurrency(voyagePriceDTO.Currency.Name))
            {
                _logger.LogError($"{nameof(UpdatePrice)}: Not Supported Currency {voyagePriceDTO.Currency.Name}");
                return;
            }

            if (!IsVoyageExists(voyagePriceDTO.VoyageCode))
            {
                _logger.LogError($"{nameof(UpdatePrice)}: Error in Voyage Code {voyagePriceDTO.VoyageCode}");
                return;
            }

            #endregion

            var currency = _serviceDeliveryDbContext.Currencies.SingleOrDefault(currnecy =>
                    string.Equals(currnecy.Name, voyagePriceDTO.Currency.Name, StringComparison.InvariantCultureIgnoreCase)
            );

            // We should use Mapping here, like AutoMapper
            var voyagePrice = new VoyagePrice
            {
                CurrencyId = currency.Id,
                Price = voyagePriceDTO.Currency.Price,
                Timestamp = voyagePriceDTO.Timestamp,
                VoyageCode = voyagePriceDTO.VoyageCode
            };

            _serviceDeliveryDbContext.VoyagePrices.Update(voyagePrice);
            await _serviceDeliveryDbContext.SaveChangesAsync();

            _logger.LogInformation($"{nameof(UpdatePrice)}: Updated container price for {voyagePriceDTO.VoyageCode}");
        }

        #region Private Methods

        private bool IsSupportedCurrency(string currencyName)
        {
            var currency = _serviceDeliveryDbContext.Currencies
                .SingleOrDefault(currency => string.Equals(currency.Name, currencyName,
                StringComparison.InvariantCultureIgnoreCase));

            return currency is null ? false : true;
        }

        private bool IsVoyageExists(string voyageCode)
        {
            if (string.IsNullOrEmpty(voyageCode))
            {
                return false;
            }

            var voyage = _serviceDeliveryDbContext.VoyagePrices
            .FirstOrDefault(voyage => string.Equals(voyage.VoyageCode, voyageCode,
            StringComparison.InvariantCultureIgnoreCase));

            return voyage is null ? false : true;
        }

        #endregion
    }
}
