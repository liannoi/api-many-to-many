namespace ManyToMany.System.Core.Domain.Entities
{
    public class BooksAuthors
    {
        public int AuthorId { get; set; }
        public int BookId { get; set; }

        public Authors Author { get; set; }
        public Books Book { get; set; }
    }
}