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
            CreateMap<CreateRequestDTO, Request>();
            CreateMap<Client, GetClientDTO>();
            CreateMap<Employee, GetEmployeeDTO>();
            CreateMap<Request, GetRequestDTO>();
            CreateMap<GetRequestDTO, Request>();
            CreateMap<GetClientDTO, Client>();

            CreateMap<Client_RequestRelashionship, GetClient_RequestRelashionshipDTO>()
            .ForMember(dest => dest.Request, opt => opt.MapFrom(src => src.Request))
            .ForMember(dest => dest.Client, opt => opt.MapFrom(src => src.Client))
            .ForMember(dest => dest.OwnershipType, opt => opt.MapFrom(src => src.OwnershipType))
            .ForMember(dest => dest.RequestId, opt => opt.MapFrom(src => src.RequestId))
            .ForMember(dest => dest.ClientId, opt => opt.MapFrom(src => src.ClientId));

            CreateMap<ActivityType, GetActivityTypeDTO>()
            .ForMember(dest => dest.TaskTypes, opt => opt.MapFrom(src => src.TaskTypes));

            // Mapping from TaskType to GetTaskTypeDTO
            CreateMap<TaskType, GetTaskTypeDTO>();

            // Reverse mapping from GetActivityTypeDTO to ActivityType
            CreateMap<GetActivityTypeDTO, ActivityType>()
                .ForMember(dest => dest.TaskTypes, opt => opt.MapFrom(src => src.TaskTypes));

            // Reverse mapping from GetTaskTypeDTO to TaskType
            CreateMap<GetTaskTypeDTO, TaskType>();

        }
    }
}
