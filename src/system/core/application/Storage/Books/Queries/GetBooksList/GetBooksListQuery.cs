using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using ManyToMany.System.Core.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ManyToMany.System.Core.Application.Storage.Books.Queries.GetBooksList
{
    public class GetBooksListQuery : IRequest<BooksListViewModel>
    {
        public class GetBooksListQueryHandler : IRequestHandler<GetBooksListQuery, BooksListViewModel>
        {
            private readonly ILibraryContext _context;
            private readonly IMapper _mapper;

            public GetBooksListQueryHandler(ILibraryContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<BooksListViewModel> Handle(GetBooksListQuery request, CancellationToken cancellationToken)
            {
                return new BooksListViewModel
                {
                    Books = await _context.Books
                        .ProjectTo<BookDto>(_mapper.ConfigurationProvider)
                        .ToListAsync(cancellationToken)
                };
            }
        }
    }
}