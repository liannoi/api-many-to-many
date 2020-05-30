using System.Collections.Generic;

namespace ManyToMany.System.Core.Application.Storage.Books.Queries.GetBooksList
{
    public class BooksListViewModel
    {
        public IList<BookDto> Books { get; set; }
    }
}