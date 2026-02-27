using Investidor.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Investidor.Tests.Features.Asset
{
    [CollectionDefinition(nameof(AssetCollection))]
    public class AssetCollection : ICollectionFixture<AssetTestsFixture> { }

    public class AssetTestsFixture : IDisposable
    {
        public Exchange GetExchangeB3()
        {
            return Exchange.B3;
        }

        public void Dispose()
        {

        }
    }
}
