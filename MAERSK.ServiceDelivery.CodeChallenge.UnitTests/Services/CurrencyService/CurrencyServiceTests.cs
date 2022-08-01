// This code is private to MAERSK
// Copyright 2022

using FluentAssertions;
using MAERSK.ServiceDelivery.CodeChallenge.APIs.Models;
using MAERSK.ServiceDelivery.CodeChallenge.APIs.Services;
using MAERSK.ServiceDelivery.CodeChallenge.UnitTests.Helpers;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace MAERSK.ServiceDelivery.CodeChallenge.UnitTests.Services.CurrencyService
{
    public class CurrencyServiceTests
    {
        #region Members

        private readonly Mock<ICurrencyService> _currencyService;
        private const int NumberOfSupportedCurrencies = 4;

        #endregion

        #region Ctor

        public CurrencyServiceTests()
        {
            _currencyService = new Mock<ICurrencyService>();
        }

        #endregion

        #region Setup

        [SetUp]
        public void Setup()
        {
            _currencyService
                .Setup(service => service.GetSupportedCurrencies())
                .Returns(CurrencyHelper.PopulateData());
        }

        #endregion

        #region GetSupportedCurrenciesTests

        [Test]
        [Category("GetSupportedCurrencies")]
        public void GetSupportedCurrencies_WhenGetCalled_AListOfCurrenciesIsNotNull()
        {
            // Arrange

            // Act
            var actualSupportedCurrencies = _currencyService.Object.GetSupportedCurrencies();

            // Assert
            actualSupportedCurrencies.Should().NotBeNull();
        }

        [Test]
        [Category("GetSupportedCurrencies")]
        public void GetSupportedCurrencies_WhenGetCalled_AListOfCurrenciesIsExpected()
        {
            // Arrange

            var expectedNumberOfSupportedCurrencies = NumberOfSupportedCurrencies;

            // Act
            var actualSupportedCurrencies = _currencyService.Object.GetSupportedCurrencies();

            // Assert
            actualSupportedCurrencies.Count.Should().Be(expectedNumberOfSupportedCurrencies);
        }

        [Test]
        [TestCase("USD")]
        [TestCase("EUR")]
        [TestCase("DKK")]
        [TestCase("GBP")]
        [Category("GetSupportedCurrencies")]
        public void GetSupportedCurrencies_WhenGetCalled_AListOfMatchedCurrenciesIsExpected(string currencyName)
        {
            // Arrange
            // Act
            var actualSupportedCurrencies = _currencyService.Object.GetSupportedCurrencies();

            // Assert
            actualSupportedCurrencies.Should().Contain(c => c.Name == currencyName);
        }

        #endregion
    }
}
