// This code is private to MAERSK
// Copyright 2022

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Currency>().HasData(new List<Currency>
            {
                new Currency {Id = 1, Name = "USD" },
                new Currency {Id = 2, Name = "EUR" },
                new Currency {Id = 3, Name = "DKK" },
                new Currency {Id = 4, Name = "GBP" }
            });

            builder.Entity<VoyagePrice>().HasData(new List<VoyagePrice>
            {
                new VoyagePrice {
                    Id = Guid.NewGuid(),
                    Price = 100,
                    CurrencyId = 1,
                    Timestamp = DateTimeOffset.UtcNow,
                    VoyageCode = "Voyage100"
                },

                new VoyagePrice {
                    Id = Guid.NewGuid(),
                    Price = 130,
                    CurrencyId = 1,
                    Timestamp = DateTimeOffset.UtcNow,
                    VoyageCode = "Voyage100"
                },

                new VoyagePrice {
                    Id = Guid.NewGuid(),
                    Price = 210,
                    CurrencyId = 3,
                    Timestamp = DateTimeOffset.UtcNow,
                    VoyageCode = "Voyage200"
                },

                new VoyagePrice {
                    Id = Guid.NewGuid(),
                    Price = 105,
                    CurrencyId = 1,
                    Timestamp = DateTimeOffset.UtcNow,
                    VoyageCode = "Voyage100"
                },
            });
        }
    }
}
