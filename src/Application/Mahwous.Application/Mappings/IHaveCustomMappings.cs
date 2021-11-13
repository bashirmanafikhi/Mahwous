using AutoMapper;

namespace Mahwous.Application.Mappings
{
    // In case complex mapping is required through this option you
    // can create custom mapping rules
    public interface IHaveCustomMappings
    {
        void CreateMappings(IMapperConfigurationExpression configuration);
    }
}
