using System;
using ManyToMany.System.Infrastructure.Persistence;

namespace ManyToMany.System.Core.Application.UnitTests.Core.Cqrs
{
    public class CommandTestBase : IDisposable
    {
        protected readonly LibraryContext _context;

        public CommandTestBase()
        {
            _context = LibraryContextFactory.Create();
        }

        public void Dispose()
        {
            LibraryContextFactory.Destroy(_context);
        }
    }
}