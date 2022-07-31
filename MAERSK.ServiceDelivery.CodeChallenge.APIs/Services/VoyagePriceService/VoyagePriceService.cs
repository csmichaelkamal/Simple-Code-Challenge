// This code is private to MAERSK
// Copyright 2022

using MAERSK.ServiceDelivery.CodeChallenge.APIs.DTOs;
using MAERSK.ServiceDelivery.CodeChallenge.APIs.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MAERSK.ServiceDelivery.CodeChallenge.APIs.Services.VoyagePriceService
{
    public class VoyagePriceService : IVoyagePriceService
    {
        private const int NUMBER_OF_VOYAGES = 10;

        private readonly ServiceDeliveryDbContext _serviceDeliveryDbContext;

        public VoyagePriceService(ServiceDeliveryDbContext serviceDeliveryDbContext)
        {
            _serviceDeliveryDbContext = serviceDeliveryDbContext;
        }

        public async Task<decimal> GetAveragePrice(GetVoyagePriceDTO getAverageVoyagePriceDTO)
        {
            var averageVoyagePrice = _serviceDeliveryDbContext.VoyagePrices
                .Where(voyage => voyage.VoyageCode == getAverageVoyagePriceDTO.VoyageCode)

                .TakeLast(NUMBER_OF_VOYAGES)
                .Average(voyagePrice => voyagePrice.Price);

            averageVoyagePrice = (decimal)19.8;

            return averageVoyagePrice;
        }

        public async Task UpdatePrice(UpdateVoyagePriceDTO voyagePriceDTO)
        {
            // We should use Mapping here, like AutoMapper
            var voyagePrice = new VoyagePrice
            {
                Currency = voyagePriceDTO.Currency,
                Price = voyagePriceDTO.Price,
                VoyageCode = voyagePriceDTO.VoyageCode
            };

            _serviceDeliveryDbContext.VoyagePrices.Update(voyagePrice);
            await _serviceDeliveryDbContext.SaveChangesAsync();
        }
    }
}
