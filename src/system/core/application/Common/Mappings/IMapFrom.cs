using AutoMapper;

namespace ManyToMany.System.Core.Application.Common.Mappings
{
    public interface IMapFrom<T>
    {
        void Mapping(Profile profile)
        {
            profile.CreateMap(typeof(T), GetType());
        }
    }
}