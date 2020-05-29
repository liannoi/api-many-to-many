using System.Threading;
using System.Threading.Tasks;
using ManyToMany.System.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ManyToMany.System.Core.Application.Common.Interfaces
{
    public interface ILibraryContext
    {
        DbSet<Authors> Authors { get; set; }
        DbSet<Books> Books { get; set; }
        DbSet<BooksAuthors> BooksAuthors { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}