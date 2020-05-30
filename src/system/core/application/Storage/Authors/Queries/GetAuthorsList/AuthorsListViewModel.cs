using System.Collections.Generic;

namespace ManyToMany.System.Core.Application.Storage.Authors.Queries.GetAuthorsList
{
    public class AuthorsListViewModel
    {
        public IList<AuthorDto> Authors { get; set; }
    }
}