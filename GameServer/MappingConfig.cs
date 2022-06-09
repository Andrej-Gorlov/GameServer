using AutoMapper;
using GameServer.Domain.Entity;
using GameServer.Domain.Entity.Dto;

namespace GameServer
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(x => {
                x.CreateMap<Server, ServerDto>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
