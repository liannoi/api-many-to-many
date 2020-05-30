using AutoMapper;
using ManyToMany.System.Core.Application.Common.Mappings;

namespace ManyToMany.System.Core.Application.Storage.Books.Queries.GetBooksList
{
    public class BookDto : IMapFrom<Domain.Entities.Books>
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public int PublishYear { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Books, BookDto>()
                .ForMember(dest => dest.BookId, opt => opt.MapFrom(s => s.BookId))
                .ForMember(dest => dest.BookName, opt => opt.MapFrom(s => s.BookName))
                .ForMember(dest => dest.PublishYear, opt => opt.MapFrom(s => s.PublishYear));
        }
    }
}