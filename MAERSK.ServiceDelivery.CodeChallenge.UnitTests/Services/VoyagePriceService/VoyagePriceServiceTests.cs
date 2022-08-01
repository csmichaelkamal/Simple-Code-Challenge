// This code is private to MAERSK
// Copyright 2022

using FluentAssertions;
using MAERSK.ServiceDelivery.CodeChallenge.APIs.DTOs;
using MAERSK.ServiceDelivery.CodeChallenge.APIs.Models;
using MAERSK.ServiceDelivery.CodeChallenge.APIs.Responses.VoyagePrices;
using MAERSK.ServiceDelivery.CodeChallenge.APIs.Services.VoyagePriceService;
using MAERSK.ServiceDelivery.CodeChallenge.UnitTests.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MAERSK.ServiceDelivery.CodeChallenge.UnitTests.Services.VoyagePriceServiceTests
{
    public class VoyagePriceServiceTests
    {
        #region Members

        private readonly Mock<IVoyagePriceService> _voyagePriceService;
        private readonly Mock<ILogger<VoyagePriceService>> _logger;
        private readonly Mock<ServiceDeliveryDbContext> _dbContext;

        #endregion

        #region Ctor

        public VoyagePriceServiceTests()
        {
            _logger = new Mock<ILogger<VoyagePriceService>>();
            _dbContext = new Mock<ServiceDeliveryDbContext>();
            _voyagePriceService = new Mock<IVoyagePriceService>();
        }

        #endregion

        #region Setup

        [SetUp]
        public void Setup()
        {
        }

        #endregion

        #region Tests

        #region GetAveragePriceTests

        [Test]
        [Category("GetAveragePrice")]
        public void GetAveragePrice_WhenGetCalled_ANotNullResultIsExpected()
        {
            // Arrange

            // Act
            var actualAveragePrice = _voyagePriceService.Object
                .GetAveragePrice(It.IsAny<GetVoyagePriceDTO>());

            // Assert
            actualAveragePrice.Should().NotBeNull();
        }

        [Test]
        [Category("GetAveragePrice")]
        public async Task GetAveragePrice_WhenGetCalled_AnAveragePriceIsExpected()
        {
            // Arrange

            var expectedResult = new GetAveragePriceResponse
            {
                AveragePrice = 40,
                VoyageCode = "VoyageCode101"
            };

            _voyagePriceService
                .Setup(vps => vps.GetAveragePrice(It.IsAny<GetVoyagePriceDTO>()))
                .ReturnsAsync(expectedResult);

            // Act
            var actualAveragePrice = await _voyagePriceService.Object
                .GetAveragePrice(It.IsAny<GetVoyagePriceDTO>())
                .ConfigureAwait(false);

            // Assert
            actualAveragePrice.Should().Be(expectedResult);
        }

        #endregion

        #region UpdatePriceTests

        [Test]
        [Category("UpdatePrice")]
        public async Task UpdatePrice_WhenGetCalled_AveragePriceIsExpected()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ServiceDeliveryDbContext>()
            .UseInMemoryDatabase(databaseName: "Shipment")
            .Options;

            using var context = new ServiceDeliveryDbContext(options);
            context.VoyagePrices.Add(new VoyagePrice
            {
                Id = Guid.NewGuid(),
                CurrencyId = 1,
                Price = 100,
                VoyageCode = "VoyageCode101"
            });

            context.Currencies.AddRange(CurrencyHelper.PopulateData());

            context.SaveChanges();

            // Act
            var voyageService = new VoyagePriceService(context, _logger.Object);

            await voyageService.UpdatePrice(new UpdateVoyagePriceDTO
            {
                Currency = new CurrencyDTO { Name = "USD", Price = 109 },
                VoyageCode = "VoyageCode101",
                Timestamp = DateTimeOffset.UtcNow
            }).ConfigureAwait(false);

            // Assert
            var actual = voyageService.GetAveragePrice(new GetVoyagePriceDTO { CurrencyName = "USD", VoyageCode = "VoyageCode101" })
                .Result;

            actual.Should().NotBeNull();
            actual.VoyageCode.Should().Be("VoyageCode101");
            actual.AveragePrice.Should().Be((decimal)104.5);

        }

        #endregion

        #endregion
    }
}
