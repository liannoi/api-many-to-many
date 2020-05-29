using System.Collections.Generic;

namespace ManyToMany.System.Core.Domain.Entities
{
    public class Books
    {
        public Books()
        {
            BooksAuthors = new HashSet<BooksAuthors>();
        }

        public int BookId { get; set; }
        public string BookName { get; set; }
        public int PublishYear { get; set; }

        public virtual ICollection<BooksAuthors> BooksAuthors { get; set; }
    }
}