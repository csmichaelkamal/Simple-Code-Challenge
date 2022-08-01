// This code is private to MAERSK
// Copyright 2022

using NUnit.Framework;

namespace MAERSK.ServiceDelivery.CodeChallenge.UnitTests.Controllers.VoyagePrices
{
    public class VoyagePricesTests
    {
        #region Setup

        [SetUp]
        public void Setup()
        {
        }

        #endregion

        #region UpdatePrice Tests

        [Test]
        [Category("UpdatePrice")]
        public void UpdatePrice()
        {
            Assert.Pass();
        }

        #endregion

        #region GetAveragePrice Tests

        [Test]
        [Category("GetAveragePrice")]
        public void GetAveragePrice_WhenCurrencyIsNull_BadRequestIsExpected()
        {
            Assert.Pass();
        }

        #endregion
    }
}