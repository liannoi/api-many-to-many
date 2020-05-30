using AutoMapper;
using ManyToMany.System.Core.Application.Common.Mappings;

namespace ManyToMany.System.Core.Application.Storage.Authors.Queries.GetAuthorsList
{
    public class AuthorDto : IMapFrom<Domain.Entities.Authors>
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string AuthorLastName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Authors, AuthorDto>()
                .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(s => s.AuthorId))
                .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(s => s.AuthorName))
                .ForMember(dest => dest.AuthorLastName, opt => opt.MapFrom(s => s.AuthorLastName));
        }
    }
}