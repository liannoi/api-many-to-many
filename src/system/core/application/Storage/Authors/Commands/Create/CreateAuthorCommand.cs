using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ManyToMany.System.Core.Application.Common.Interfaces;
using ManyToMany.System.Core.Application.Storage.Books.Queries.GetBooksList;
using ManyToMany.System.Core.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ManyToMany.System.Core.Application.Storage.Authors.Commands.Create
{
    public class CreateAuthorCommand : IRequest
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string AuthorLastName { get; set; }
        public BooksListViewModel BooksListViewModel { get; set; }

        public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand>
        {
            private readonly ILibraryContext _context;
            private readonly IMediator _mediator;

            public CreateAuthorCommandHandler(ILibraryContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<Unit> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
            {
                var result = await _context.Authors.AddAsync(new Domain.Entities.Authors
                {
                    AuthorName = request.AuthorName,
                    AuthorLastName = request.AuthorLastName
                }, cancellationToken);

                await _context.SaveChangesAsync(cancellationToken);
                await TryInitializeBooksAsync(request, result, cancellationToken);
                await _mediator.Publish(new AuthorCreated {AuthorId = result.Entity.AuthorId}, cancellationToken);

                return Unit.Value;
            }


            #region Helpers

            private async Task TryInitializeBooksAsync(CreateAuthorCommand request,
                EntityEntry<Domain.Entities.Authors> result, CancellationToken cancellationToken)
            {
                var books = request.BooksListViewModel?.Books;

                if (books?.Any() != true) return;

                foreach (var book in books)
                    await _context.BooksAuthors.AddAsync(new BooksAuthors
                    {
                        AuthorId = result.Entity.AuthorId,
                        Book = await _context.Books
                            .Where(e => e.BookId == book.BookId)
                            .FirstOrDefaultAsync(cancellationToken)
                    }, cancellationToken);

                await _context.SaveChangesAsync(cancellationToken);
            }

            #endregion
        }
    }
}