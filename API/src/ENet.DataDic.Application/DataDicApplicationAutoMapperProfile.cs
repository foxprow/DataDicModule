using AutoMapper;
using ENet.DataDic.Dtos;

namespace ENet.DataDic
{
    public class DataDicApplicationAutoMapperProfile : Profile
    {
        public DataDicApplicationAutoMapperProfile()
        {
            CreateMap<DataDictionaryAddOrUpdateDto, DataDictionary>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.TenantId, opt => opt.Ignore());
            CreateMap<DataDictionary, DataDictionaryInfoDto>();
            CreateMap<DataDictionary, DataDictionaryListDto>();
        }
    }
}