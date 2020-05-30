using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ManyToMany.System.Core.Application.Common.Interfaces;
using ManyToMany.System.Core.Application.Storage.Authors.Queries.GetAuthorsList;
using ManyToMany.System.Core.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ManyToMany.System.Core.Application.Storage.Books.Commands.Create
{
    public class CreateBookCommand : IRequest
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public int PublishYear { get; set; }
        public AuthorsListViewModel AuthorsListViewModel { get; set; }

        public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand>
        {
            private readonly ILibraryContext _context;
            private readonly IMediator _mediator;

            public CreateBookCommandHandler(ILibraryContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<Unit> Handle(CreateBookCommand request, CancellationToken cancellationToken)
            {
                var result = await _context.Books.AddAsync(new Domain.Entities.Books
                {
                    BookName = request.BookName,
                    PublishYear = request.PublishYear
                }, cancellationToken);

                await _context.SaveChangesAsync(cancellationToken);
                await TryInitializeAuthorsAsync(request, result, cancellationToken);
                await _mediator.Publish(new BookCreated {BookId = result.Entity.BookId}, cancellationToken);

                return Unit.Value;
            }

            #region Helpers

            private async Task TryInitializeAuthorsAsync(CreateBookCommand request,
                EntityEntry<Domain.Entities.Books> result, CancellationToken cancellationToken)
            {
                var authors = request.AuthorsListViewModel?.Authors;

                if (authors?.Any() != true) return;

                foreach (var author in authors)
                    await _context.BooksAuthors.AddAsync(new BooksAuthors
                    {
                        BookId = result.Entity.BookId,
                        Author = await _context.Authors
                            .Where(e => e.AuthorId == author.AuthorId)
                            .FirstOrDefaultAsync(cancellationToken)
                    }, cancellationToken);

                await _context.SaveChangesAsync(cancellationToken);
            }

            #endregion
        }
    }
}