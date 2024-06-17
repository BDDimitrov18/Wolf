using AutoMapper;
using DataAccessLayer.Models;
using WolfAPI.DTO;

namespace WolfAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateEmployeeDTO, Employee>();


        }
    }
}
