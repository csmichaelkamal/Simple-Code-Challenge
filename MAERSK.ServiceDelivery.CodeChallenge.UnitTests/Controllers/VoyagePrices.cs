// This code is private to MAERSK
// Copyright 2022

using FluentAssertions;
using MAERSK.ServiceDelivery.CodeChallenge.APIs.Controllers;
using MAERSK.ServiceDelivery.CodeChallenge.APIs.DTOs;
using MAERSK.ServiceDelivery.CodeChallenge.APIs.Requests.VoyagePrices;
using MAERSK.ServiceDelivery.CodeChallenge.APIs.Services.VoyagePriceService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace MAERSK.ServiceDelivery.CodeChallenge.UnitTests.Controllers.VoyagePrices
{
    public class VoyagePricesTests
    {
        #region Members

        private readonly Mock<IVoyagePriceService> _voyagePriceService;
        private readonly Mock<ILogger<VoyagePricesController>> _logger;
        private readonly VoyagePricesController _voyagePricesController;

        private const string VoyageCode = "VoyageCode101";

        #endregion

        #region Ctor

        public VoyagePricesTests()
        {
            _logger = new Mock<ILogger<VoyagePricesController>>();
            _voyagePriceService = new Mock<IVoyagePriceService>();

            _voyagePricesController = new VoyagePricesController(_voyagePriceService.Object,
                _logger.Object);
        }

        #endregion

        #region Setup

        [SetUp]
        public void Setup()
        {

        }

        #endregion

        #region UpdatePrice Tests

        [Test]
        [Category("UpdatePrice")]
        public async Task UpdatePrice_WhenGetCalled_UpdatePriceInTheServiceIsCalledExactlyOnce()
        {
            // Arrange
            var updatePriceRequest = new UpdatePriceRequest
            {
                Currency = new CurrencyDTO
                {
                    Name = "DKK",
                    Price = 250
                },
                VoyageCode = VoyageCode,
                Timestamp = DateTimeOffset.UtcNow
            };

            _voyagePriceService.Setup(vps => vps.UpdatePrice(It.IsAny<UpdateVoyagePriceDTO>()))
                           .Returns(Task.CompletedTask);

            // Act
            await _voyagePricesController.UpdatePrice(updatePriceRequest);

            // Assert
            _voyagePriceService.Verify(vps => vps.UpdatePrice(It.IsAny<UpdateVoyagePriceDTO>()), Times.Exactly(1));
        }

        #endregion

        #region GetAveragePrice Tests

        [Test]
        [Category("GetAveragePrice")]
        public async Task GetAveragePrice_WhenVoyageCodeIsNull_NotFoundResultIsExpected()
        {
            // Arrange
            var expectedType = typeof(NotFoundResult);

            // Act
            var actual = await _voyagePricesController.GetAveragePrice(It.IsAny<string>(), "USD");

            // Assert
            actual.Should().BeOfType(expectedType);
        }

        [Test]
        [Category("GetAveragePrice")]
        public async Task GetAveragePrice_WhenCurrencyIsNull_NotFoundResultIsExpected()
        {
            // Arrange
            var expectedType = typeof(NotFoundResult);

            // Act
            var actual = await _voyagePricesController.GetAveragePrice(VoyageCode, It.IsAny<string>());

            // Assert
            actual.Should().BeOfType(expectedType);
        }

        [Test]
        [Category("GetAveragePrice")]
        public async Task GetAveragePrice_WhenCurrencyIsNull_GetAveragePriceFromServiceIsCalledExactlyOnce()
        {
            // Act
            await _voyagePricesController.GetAveragePrice(It.IsAny<string>(), It.IsAny<string>());

            // Assert
            _voyagePriceService.Verify(vps => vps.GetAveragePrice(It.IsAny<GetVoyagePriceDTO>()), Times.Exactly(1));
        }


        #endregion
    }
}