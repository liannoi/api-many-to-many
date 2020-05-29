namespace ManyToMany.System.Core.Domain.Entities
{
    public class BooksAuthors
    {
        public int AuthorId { get; set; }
        public int BookId { get; set; }

        public virtual Authors Author { get; set; }
        public virtual Books Book { get; set; }
    }
}