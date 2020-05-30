using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ManyToMany.System.Core.Application.Storage.Books.Queries.GetBookDetail;
using ManyToMany.System.Core.Application.UnitTests.Common.Cqrs;
using ManyToMany.System.Infrastructure.Persistence;
using Shouldly;
using Xunit;

namespace ManyToMany.System.Core.Application.UnitTests.Storage.Books.Queries
{
    [Collection("QueryCollection")]
    public class GetBookDetailQueryHandlerTests
    {
        private readonly LibraryContext _context;
        private readonly IMapper _mapper;

        public GetBookDetailQueryHandlerTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        public async Task ShouldReturnsBookDetailViewModelGivenExistingId(int id)
        {
            // Arrange
            var sut = new GetBookDetailQuery.GetBookDetailQueryHandler(_context, _mapper);

            // Act
            var actual = await sut.Handle(new GetBookDetailQuery {BookId = id}, CancellationToken.None);

            // Assert
            actual.ShouldBeOfType<BookDetailViewModel>();
            actual.BookId.ShouldBe(id);
        }
    }
}