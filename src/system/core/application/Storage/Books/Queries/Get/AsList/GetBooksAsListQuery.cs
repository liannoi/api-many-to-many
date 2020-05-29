using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using ManyToMany.System.Core.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ManyToMany.System.Core.Application.Storage.Books.Queries.Get.AsList
{
    public class GetBooksAsListQuery : IRequest<BooksListViewModel>
    {
        public class GetBooksAsListQueryHandler : IRequestHandler<GetBooksAsListQuery, BooksListViewModel>
        {
            private readonly ILibraryContext _context;
            private readonly IMapper _mapper;

            public GetBooksAsListQueryHandler(ILibraryContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<BooksListViewModel> Handle(GetBooksAsListQuery request,
                CancellationToken cancellationToken)
            {
                return new BooksListViewModel
                {
                    Books = await _context.Books
                        .ProjectTo<BookLookupDto>(_mapper.ConfigurationProvider)
                        .ToListAsync(cancellationToken)
                };
            }
        }
    }
}