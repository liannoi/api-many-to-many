using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ManyToMany.System.Core.Application.Storage.Books.Queries.Get.AsList;
using ManyToMany.System.Core.Application.UnitTests.Core.Cqrs;
using ManyToMany.System.Infrastructure.Persistence;
using Shouldly;
using Xunit;

namespace ManyToMany.System.Core.Application.UnitTests.Storage.Books.Queries.Get.AsList
{
    [Collection("QueryCollection")]
    public class GetBooksAsListQueryHandlerTests
    {
        public GetBooksAsListQueryHandlerTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        private readonly LibraryContext _context;
        private readonly IMapper _mapper;

        [Fact]
        public async Task ShouldReturnsAllItems()
        {
            // Arrange
            var sut = new GetBooksAsListQuery.GetBooksAsListQueryHandler(_context, _mapper);

            // Act
            var actual = await sut.Handle(new GetBooksAsListQuery(), CancellationToken.None);

            // Assert
            actual.Books.Count.ShouldBe(3);
        }

        [Fact]
        public async Task ShouldReturnsBooksListViewModel()
        {
            // Arrange
            var sut = new GetBooksAsListQuery.GetBooksAsListQueryHandler(_context, _mapper);

            // Act
            var actual = await sut.Handle(new GetBooksAsListQuery(), CancellationToken.None);

            // Assert
            actual.ShouldBeOfType<BooksListViewModel>();
        }
    }
}