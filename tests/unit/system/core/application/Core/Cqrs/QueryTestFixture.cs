using System;
using AutoMapper;
using ManyToMany.System.Core.Application.Common.Mappings;
using ManyToMany.System.Infrastructure.Persistence;

namespace ManyToMany.System.Core.Application.UnitTests.Core.Cqrs
{
    public class QueryTestFixture : IDisposable
    {
        public QueryTestFixture()
        {
            Context = LibraryContextFactory.Create();
            Mapper = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>()).CreateMapper();
        }

        public LibraryContext Context { get; }
        public IMapper Mapper { get; }

        public void Dispose()
        {
            LibraryContextFactory.Destroy(Context);
        }
    }
}