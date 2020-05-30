using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using ManyToMany.System.Core.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ManyToMany.System.Core.Application.Storage.Books.Queries.Get
{
    public class GetBookQuery : IRequest<BookDto>
    {
        public int BookId { get; set; }

        public class GetBookQueryHandler : IRequestHandler<GetBookQuery, BookDto>
        {
            private readonly ILibraryContext _context;
            private readonly IMapper _mapper;

            public GetBookQueryHandler(ILibraryContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<BookDto> Handle(GetBookQuery request, CancellationToken cancellationToken)
            {
                return await _context.Books
                    .Where(e => e.BookId == request.BookId)
                    .ProjectTo<BookDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(cancellationToken);
            }
        }
    }
}