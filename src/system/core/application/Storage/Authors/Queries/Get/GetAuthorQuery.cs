using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using ManyToMany.System.Core.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ManyToMany.System.Core.Application.Storage.Authors.Queries.Get
{
    public class GetAuthorQuery : IRequest<AuthorDto>
    {
        public int AuthorId { get; set; }

        public class GetAuthorQueryHandler : IRequestHandler<GetAuthorQuery, AuthorDto>
        {
            private readonly ILibraryContext _context;
            private readonly IMapper _mapper;

            public GetAuthorQueryHandler(ILibraryContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<AuthorDto> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
            {
                return await _context.Authors
                    .Where(e => e.AuthorId == request.AuthorId)
                    .ProjectTo<AuthorDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(cancellationToken);
            }
        }
    }
}