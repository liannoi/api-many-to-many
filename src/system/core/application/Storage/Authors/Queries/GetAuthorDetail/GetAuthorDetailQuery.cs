using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using ManyToMany.System.Core.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ManyToMany.System.Core.Application.Storage.Authors.Queries.GetAuthorDetail
{
    public class GetAuthorDetailQuery : IRequest<AuthorDetailViewModel>
    {
        public int AuthorId { get; set; }

        public class GetAuthorDetailQueryHandler : IRequestHandler<GetAuthorDetailQuery, AuthorDetailViewModel>
        {
            private readonly ILibraryContext _context;
            private readonly IMapper _mapper;

            public GetAuthorDetailQueryHandler(ILibraryContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<AuthorDetailViewModel> Handle(GetAuthorDetailQuery request,
                CancellationToken cancellationToken)
            {
                return await _context.Authors
                    .Where(e => e.AuthorId == request.AuthorId)
                    .ProjectTo<AuthorDetailViewModel>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(cancellationToken);
            }
        }
    }
}