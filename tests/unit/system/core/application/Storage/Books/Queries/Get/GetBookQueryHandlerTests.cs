using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ManyToMany.System.Core.Application.Storage.Books;
using ManyToMany.System.Core.Application.Storage.Books.Queries.Get;
using ManyToMany.System.Core.Application.UnitTests.Core.Cqrs;
using ManyToMany.System.Infrastructure.Persistence;
using Shouldly;
using Xunit;

namespace ManyToMany.System.Core.Application.UnitTests.Storage.Books.Queries.Get
{
    [Collection("QueryCollection")]
    public class GetBookQueryHandlerTests
    {
        private readonly LibraryContext _context;
        private readonly IMapper _mapper;

        public GetBookQueryHandlerTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        public async Task ShouldReturnsBookDtoWithCorrectId(int id)
        {
            // Arrange
            var sut = new GetBookQuery.GetBookQueryHandler(_context, _mapper);

            // Act
            var actual = await sut.Handle(new GetBookQuery {BookId = id}, CancellationToken.None);

            // Assert
            actual.ShouldBeOfType<BookDto>();
            actual.BookId.ShouldBe(id);
        }
    }
}