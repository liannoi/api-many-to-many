using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ManyToMany.System.Core.Application.Common.Mappings;
using ManyToMany.System.Core.Application.Storage.Books.Queries.GetBooksList;

namespace ManyToMany.System.Core.Application.Storage.Authors.Queries.GetAuthorDetail
{
    public class AuthorDetailViewModel : IMapFrom<Domain.Entities.Authors>
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string AuthorLastName { get; set; }

        public IEnumerable<BookDto> Books { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Authors, AuthorDetailViewModel>()
                .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(s => s.AuthorId))
                .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(s => s.AuthorName))
                .ForMember(dest => dest.AuthorLastName, opt => opt.MapFrom(s => s.AuthorLastName))
                .ForMember(dest => dest.Books, opt => opt.MapFrom(s => s.BooksAuthors.Select(x => x.Book)));
        }
    }
}