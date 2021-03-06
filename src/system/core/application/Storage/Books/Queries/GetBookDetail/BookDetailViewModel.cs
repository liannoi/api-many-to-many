using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ManyToMany.System.Core.Application.Common.Mappings;
using ManyToMany.System.Core.Application.Storage.Authors.Queries.GetAuthorsList;

namespace ManyToMany.System.Core.Application.Storage.Books.Queries.GetBookDetail
{
    public class BookDetailViewModel : IMapFrom<Domain.Entities.Books>
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public int PublishYear { get; set; }

        public IEnumerable<AuthorDto> Authors { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Books, BookDetailViewModel>()
                .ForMember(dest => dest.BookId, opt => opt.MapFrom(s => s.BookId))
                .ForMember(dest => dest.BookName, opt => opt.MapFrom(s => s.BookName))
                .ForMember(dest => dest.PublishYear, opt => opt.MapFrom(s => s.PublishYear))
                .ForMember(dest => dest.Authors, opt => opt.MapFrom(s => s.BooksAuthors.Select(e => e.Author)));
        }
    }
}