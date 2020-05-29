using System.Collections.Generic;

namespace ManyToMany.System.Core.Domain.Entities
{
    public class Authors
    {
        public Authors()
        {
            BooksAuthors = new HashSet<BooksAuthors>();
        }

        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string AuthorLastName { get; set; }

        public ICollection<BooksAuthors> BooksAuthors { get; set; }
    }
}