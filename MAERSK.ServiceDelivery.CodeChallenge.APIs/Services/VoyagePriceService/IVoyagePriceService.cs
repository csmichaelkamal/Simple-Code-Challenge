// This code is private to MAERSK
// Copyright 2022

using MAERSK.ServiceDelivery.CodeChallenge.APIs.DTOs;
using System.Threading.Tasks;

namespace MAERSK.ServiceDelivery.CodeChallenge.APIs.Services.VoyagePriceService
{
    public interface IVoyagePriceService
    {
        Task UpdatePrice(GetVoyagePriceDTO voyagePriceDTO);
    }
}
