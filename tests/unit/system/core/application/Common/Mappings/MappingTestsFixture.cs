using AutoMapper;
using ManyToMany.System.Core.Application.Common.Mappings;

namespace ManyToMany.System.Core.Application.UnitTests.Common.Mappings
{
    public class MappingTestsFixture
    {
        public MappingTestsFixture()
        {
            ConfigurationProvider = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            Mapper = ConfigurationProvider.CreateMapper();
        }

        public IConfigurationProvider ConfigurationProvider { get; }
        public IMapper Mapper { get; }
    }
}