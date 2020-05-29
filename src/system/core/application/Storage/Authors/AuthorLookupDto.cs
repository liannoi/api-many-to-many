using System.Collections.Generic;
using AutoMapper;
using ManyToMany.System.Core.Application.Common.Mappings;
using ManyToMany.System.Core.Application.Storage.Books;

namespace ManyToMany.System.Core.Application.Storage.Authors
{
    public class AuthorLookupDto : IMapFrom<Domain.Entities.Authors>
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string AuthorLastName { get; set; }

        public IEnumerable<BookLookupDto> Books { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Authors, AuthorLookupDto>()
                .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(s => s.AuthorId))
                .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(s => s.AuthorName))
                .ForMember(dest => dest.AuthorLastName, opt => opt.MapFrom(s => s.AuthorLastName));
        }
    }
}