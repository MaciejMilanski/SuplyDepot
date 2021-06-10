using System.Collections.Generic;

using AutoMapper;


namespace SupplyDepot.Server.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DataAccess.Models.Item, Shared.Item>();
            CreateMap<Shared.Item, DataAccess.Models.Item>();
        }


    }
}