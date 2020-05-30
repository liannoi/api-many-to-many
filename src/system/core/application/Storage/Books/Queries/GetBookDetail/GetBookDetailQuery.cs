using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using ManyToMany.System.Core.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ManyToMany.System.Core.Application.Storage.Books.Queries.GetBookDetail
{
    public class GetBookDetailQuery : IRequest<BookDetailViewModel>
    {
        public int BookId { get; set; }

        public class GetBookDetailQueryHandler : IRequestHandler<GetBookDetailQuery, BookDetailViewModel>
        {
            private readonly ILibraryContext _context;
            private readonly IMapper _mapper;

            public GetBookDetailQueryHandler(ILibraryContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<BookDetailViewModel> Handle(GetBookDetailQuery request,
                CancellationToken cancellationToken)
            {
                return await _context.Books
                    .Where(e => e.BookId == request.BookId)
                    .ProjectTo<BookDetailViewModel>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(cancellationToken);
            }
        }
    }
}