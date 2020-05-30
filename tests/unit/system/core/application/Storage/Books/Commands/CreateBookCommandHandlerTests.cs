using System.Threading;
using System.Threading.Tasks;
using ManyToMany.System.Core.Application.Storage.Books.Commands.Create;
using ManyToMany.System.Core.Application.UnitTests.Common.Cqrs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace ManyToMany.System.Core.Application.UnitTests.Storage.Books.Commands
{
    public class CreateBookCommandHandlerTests : CommandTestBase
    {
        [Fact]
        public async Task ShouldRaiseBookCreatedNotificationGivenValidRequest()
        {
            // Arrange
            var mediatorMock = new Mock<IMediator>();
            var sut = new CreateBookCommand.CreateBookCommandHandler(_context, mediatorMock.Object);
            var newBookId = await _context.Books.MaxAsync(e => e.BookId, It.IsAny<CancellationToken>()) + 1;

            // Act
            await sut.Handle(new CreateBookCommand(), It.IsAny<CancellationToken>());

            // Assert
            mediatorMock.Verify(m => m.Publish(It.Is<BookCreated>(cc => cc.BookId == newBookId),
                It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}