using System.Collections.Generic;

namespace ManyToMany.System.Core.Application.Storage.Authors.Queries.Get.AsList
{
    public class AuthorsListViewModel
    {
        public IList<AuthorLookupDto> Authors { get; set; }
    }
}