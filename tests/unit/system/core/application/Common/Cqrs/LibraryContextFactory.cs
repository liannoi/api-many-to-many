using System;
using ManyToMany.System.Core.Domain.Entities;
using ManyToMany.System.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ManyToMany.System.Core.Application.UnitTests.Common.Cqrs
{
    public class LibraryContextFactory
    {
        public static LibraryContext Create()
        {
            var options = new DbContextOptionsBuilder<LibraryContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new LibraryContext(options);
            context.Database.EnsureCreated();

            context.Authors.AddRange(
                new Authors {AuthorId = 1, AuthorName = "Stephen", AuthorLastName = "King"},
                new Authors {AuthorId = 2, AuthorName = "Edgar", AuthorLastName = "Poe"},
                new Authors {AuthorId = 3, AuthorName = "Charles", AuthorLastName = "Dickens"}
            );

            context.Books.AddRange(
                new Books {BookId = 1, BookName = "Animal farm", PublishYear = 1945},
                new Books {BookId = 2, BookName = "Idiot", PublishYear = 1869},
                new Books {BookId = 3, BookName = "Devils", PublishYear = 1866}
            );

            context.BooksAuthors.AddRange(
                new BooksAuthors {AuthorId = 1, BookId = 2},
                new BooksAuthors {AuthorId = 3, BookId = 1},
                new BooksAuthors {AuthorId = 3, BookId = 2}
            );

            context.SaveChanges();

            return context;
        }

        public static void Destroy(LibraryContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}