using AutoMapper;
using DataAccessLayer.Models;
using DTOS.DTO;

namespace WolfAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateEmployeeDTO, Employee>();
            CreateMap<CreateClientDTO, Client>();
            CreateMap<Client, GetClientDTO>();
            CreateMap<Employee, GetEmployeeDTO>();
        }
    }
}
