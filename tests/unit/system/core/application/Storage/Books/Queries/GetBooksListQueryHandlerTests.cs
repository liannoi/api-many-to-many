using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ManyToMany.System.Core.Application.Storage.Books.Queries.GetBooksList;
using ManyToMany.System.Core.Application.UnitTests.Common.Cqrs;
using ManyToMany.System.Infrastructure.Persistence;
using Moq;
using Shouldly;
using Xunit;

namespace ManyToMany.System.Core.Application.UnitTests.Storage.Books.Queries
{
    [Collection("QueryCollection")]
    public class GetBooksListQueryHandlerTests
    {
        public GetBooksListQueryHandlerTests(QueryTestFixture fixture)
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
            var sut = new GetBooksListQuery.GetBooksListQueryHandler(_context, _mapper);

            // Act
            var actual = await sut.Handle(new GetBooksListQuery(), It.IsAny<CancellationToken>());

            // Assert
            actual.Books.Count.ShouldBe(_context.Books.Count());
        }

        [Fact]
        public async Task ShouldReturnsBooksListViewModel()
        {
            // Arrange
            var sut = new GetBooksListQuery.GetBooksListQueryHandler(_context, _mapper);

            // Act
            var actual = await sut.Handle(new GetBooksListQuery(), It.IsAny<CancellationToken>());

            // Assert
            actual.ShouldBeOfType<BooksListViewModel>();
        }
    }
}