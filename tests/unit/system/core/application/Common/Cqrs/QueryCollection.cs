using Xunit;

namespace ManyToMany.System.Core.Application.UnitTests.Common.Cqrs
{
    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture>
    {
    }
}