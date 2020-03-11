using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Quizard.Tests.Services.Collection_Fixtures
{
    [CollectionDefinition("Mapper collection")]
    public class MapperCollection : ICollectionFixture<MapperFixture>
    {
    }
}
