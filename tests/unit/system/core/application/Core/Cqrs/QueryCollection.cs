using Xunit;

namespace ManyToMany.System.Core.Application.UnitTests.Core.Cqrs
{
    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture>
    {
    }
}