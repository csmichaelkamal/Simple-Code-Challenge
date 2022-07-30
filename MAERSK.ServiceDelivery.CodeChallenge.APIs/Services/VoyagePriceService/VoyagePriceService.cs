// This code is private to MAERSK
// Copyright 2022

using MAERSK.ServiceDelivery.CodeChallenge.APIs.DTOs;
using MAERSK.ServiceDelivery.CodeChallenge.APIs.Models;
using System.Threading.Tasks;

namespace MAERSK.ServiceDelivery.CodeChallenge.APIs.Services.VoyagePriceService
{
    public class VoyagePriceService : IVoyagePriceService
    {
        private readonly ServiceDeliveryDbContext _serviceDeliveryDbContext;

        public VoyagePriceService(ServiceDeliveryDbContext serviceDeliveryDbContext)
        {
            _serviceDeliveryDbContext = serviceDeliveryDbContext;
        }

        public async Task UpdatePrice(GetVoyagePriceDTO voyagePriceDTO)
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
