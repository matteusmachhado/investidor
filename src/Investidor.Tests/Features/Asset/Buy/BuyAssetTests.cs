using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Investidor.Tests.Features.Asset.Buy
{
    [Collection(nameof(AssetCollection))]
    public class BuyAssetTests
    {
        private readonly AssetTestsFixture _assetTestsFixture;

        public BuyAssetTests(AssetTestsFixture assetTestsFixture)
        {
            _assetTestsFixture = assetTestsFixture;
        }

        [Fact]
        public void ValidQuantity_Success()
        {
            var asset = new Domain.Entities.Asset("ITSA4", "Itaúsa", 13.87m, _assetTestsFixture.GetExchangeB3());

            asset.Buy(10);

            Assert.Equal(10, asset.Quantity);
            Assert.Equal(138.70m, asset.AmountInvested);
            Assert.Equal(13.87m, asset.AveragePrice);
        }


        [Fact]
        public void ValidUpdateCurrentPrice_Success()
        {
            var asset = new Domain.Entities.Asset("ITSA4", "Itaúsa", 13.87m, _assetTestsFixture.GetExchangeB3());

            asset.Buy(10);
            asset.UpdateCurrentPrice(14.38m);

            Assert.Equal(10, asset.Quantity);
            Assert.Equal(5.10m, asset.Gain);
            Assert.Equal(3.68m, Math.Round(asset.PercentageGain, 2));
        }

        [Fact]
        public void MultiplePurchases_Success()
        {
            var asset = new Domain.Entities.Asset("ITSA4", "Itaúsa", 20m, _assetTestsFixture.GetExchangeB3());

            asset.Buy(10); // 200

            asset.UpdateCurrentPrice(30m);
            asset.Buy(10); // 300

            Assert.Equal(20, asset.Quantity);
            Assert.Equal(500m, asset.AmountInvested);
            Assert.Equal(25m, asset.AveragePrice);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-5)]
        public void InvalidQuantity_Failure(decimal quantity)
        {
            var asset = new Domain.Entities.Asset("ITSA4", "Itaúsa", 20m, _assetTestsFixture.GetExchangeB3());

            Assert.Throws<InvalidOperationException>(() =>
                asset.Buy(quantity));
        }
    }
}
