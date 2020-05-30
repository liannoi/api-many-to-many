using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using ManyToMany.System.Core.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ManyToMany.System.Core.Application.Storage.Authors.Queries.Get.AsList
{
    public class GetAuthorsAsListQuery : IRequest<AuthorsListViewModel>
    {
        public class GetAuthorsAsListQueryHandler : IRequestHandler<GetAuthorsAsListQuery, AuthorsListViewModel>
        {
            private readonly ILibraryContext _context;
            private readonly IMapper _mapper;

            public GetAuthorsAsListQueryHandler(ILibraryContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<AuthorsListViewModel> Handle(GetAuthorsAsListQuery request,
                CancellationToken cancellationToken)
            {
                return new AuthorsListViewModel
                {
                    Authors = await _context.Authors
                        .ProjectTo<AuthorDto>(_mapper.ConfigurationProvider)
                        .ToListAsync(cancellationToken)
                };
            }
        }
    }
}