using System.Collections.Generic;

namespace ManyToMany.System.Core.Application.Storage.Authors.Queries.Get.AsList
{
    public class ActorsListViewModel
    {
        public IList<AuthorLookupDto> Actors { get; set; }
    }
}