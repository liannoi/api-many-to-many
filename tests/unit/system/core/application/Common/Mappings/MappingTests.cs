using System;
using AutoMapper;
using ManyToMany.System.Core.Application.Storage.Authors.Queries.GetAuthorDetail;
using ManyToMany.System.Core.Application.Storage.Books.Queries.GetBooksList;
using ManyToMany.System.Core.Domain.Entities;
using Shouldly;
using Xunit;

namespace ManyToMany.System.Core.Application.UnitTests.Common.Mappings
{
    public class MappingTests : IClassFixture<MappingTestsFixture>
    {
        public MappingTests(MappingTestsFixture fixture)
        {
            _configuration = fixture.ConfigurationProvider;
            _mapper = fixture.Mapper;
        }

        private readonly IConfigurationProvider _configuration;
        private readonly IMapper _mapper;

        [Theory]
        [InlineData(typeof(Books), typeof(BookDto))]
        [InlineData(typeof(Authors), typeof(AuthorDetailViewModel))]
        public void ShouldSupportMappingFromSourceToDestination(Type source, Type destination)
        {
            // Arrange
            var instance = Activator.CreateInstance(source);

            // Act
            var actual = _mapper.Map(instance, source, destination);

            // Assert
            actual.ShouldBeOfType(destination);
        }

        [Fact]
        public void ShouldHaveValidConfiguration()
        {
            _configuration.AssertConfigurationIsValid();
        }
    }
}