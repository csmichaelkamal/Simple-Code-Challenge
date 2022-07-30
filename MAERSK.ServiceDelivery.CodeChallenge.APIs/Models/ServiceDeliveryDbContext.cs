// This code is private to MAERSK
// Copyright 2022

using Microsoft.EntityFrameworkCore;

namespace MAERSK.ServiceDelivery.CodeChallenge.APIs.Models
{
    public class ServiceDeliveryDbContext : DbContext
    {
        public ServiceDeliveryDbContext(DbContextOptions<ServiceDeliveryDbContext> options)
            : base(options)
        {
        }

        public DbSet<VoyagePrice> VoyagePrices { get; set; }

        public DbSet<Currency> Currencies { get; set; }


    }
}
