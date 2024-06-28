using AutoMapper;
using DataAccessLayer.Models;
using DTOS.DTO;

namespace WolfAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Existing mappings
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

            CreateMap<TaskType, GetTaskTypeDTO>();

            CreateMap<GetActivityTypeDTO, ActivityType>()
                .ForMember(dest => dest.TaskTypes, opt => opt.MapFrom(src => src.TaskTypes));

            CreateMap<GetTaskTypeDTO, TaskType>();

            CreateMap<CreateTaskTypeDTO, TaskType>();

            CreateMap<CreateActivityDTO, Activity>()
                .ForMember(dest => dest.Tasks, opt => opt.Ignore()); // Assuming CreateActivityDTO does not contain tasks

            CreateMap<Activity, GetActivityDTO>()
                .ForMember(dest => dest.Tasks, opt => opt.MapFrom(src => src.Tasks));

            CreateMap<GetActivityDTO, Activity>()
                .ForMember(dest => dest.Tasks, opt => opt.MapFrom(src => src.Tasks));

            CreateMap<WorkTask, GetTaskDTO>()
                .ForMember(dest => dest.Executant, opt => opt.MapFrom(src => src.Executant))
                .ForMember(dest => dest.Control, opt => opt.MapFrom(src => src.Control))
                .ForMember(dest => dest.taskType, opt => opt.MapFrom(src => src.taskType));

            CreateMap<GetTaskDTO, WorkTask>()
                .ForMember(dest => dest.Executant, opt => opt.MapFrom(src => src.Executant))
                .ForMember(dest => dest.Control, opt => opt.MapFrom(src => src.Control))
                .ForMember(dest => dest.taskType, opt => opt.MapFrom(src => src.taskType));

            CreateMap<CreateTaskDTO, WorkTask>()
            .ForMember(dest => dest.TaskId, opt => opt.Ignore()) // Assuming TaskId is auto-generated
            .ForMember(dest => dest.Activity, opt => opt.Ignore()) // Assuming related entities will be mapped separately
            .ForMember(dest => dest.Executant, opt => opt.Ignore())
            .ForMember(dest => dest.Control, opt => opt.Ignore())
            .ForMember(dest => dest.taskType, opt => opt.Ignore());


            CreateMap<Activity, GetActivityDTO>()
            .ForMember(dest => dest.Request, opt => opt.MapFrom(src => src.Request))
            .ForMember(dest => dest.ActivityType, opt => opt.MapFrom(src => src.ActivityType))
            .ForMember(dest => dest.Tasks, opt => opt.MapFrom(src => src.Tasks));

            CreateMap<Request, GetRequestDTO>();
            CreateMap<ActivityType, GetActivityTypeDTO>();
            CreateMap<WorkTask, GetTaskDTO>()
                .ForMember(dest => dest.Executant, opt => opt.MapFrom(src => src.Executant))
                .ForMember(dest => dest.Control, opt => opt.MapFrom(src => src.Control))
                .ForMember(dest => dest.taskType, opt => opt.MapFrom(src => src.taskType));

            CreateMap<ActivityType, CreateActivityTypeDTO>()
            .ForMember(dest => dest.ActivityTypeName, opt => opt.MapFrom(src => src.ActivityTypeName));

            CreateMap<CreateActivityTypeDTO, ActivityType>()
            .ForMember(dest => dest.ActivityTypeName, opt => opt.MapFrom(src => src.ActivityTypeName))
            .ForMember(dest => dest.TaskTypes, opt => opt.Ignore()); // Assuming TaskTypes is not set in CreateActivityTypeDTO
        }
    }
}
