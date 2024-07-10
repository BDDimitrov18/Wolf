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

            CreateMap<TaskType, GetTaskTypeDTO>();

            CreateMap<GetActivityTypeDTO, ActivityType>()
                .ForMember(dest => dest.TaskTypes, opt => opt.MapFrom(src => src.TaskTypes));

            CreateMap<GetTaskTypeDTO, TaskType>();

            CreateMap<CreateTaskTypeDTO, TaskType>();

            // Mapping from CreateActivityDTO to Activity
            CreateMap<CreateActivityDTO, Activity>()
                .ForMember(dest => dest.ActivityId, opt => opt.Ignore())
                .ForMember(dest => dest.ParentActivity, opt => opt.Ignore())
                .ForMember(dest => dest.Request, opt => opt.Ignore())
                .ForMember(dest => dest.ActivityType, opt => opt.Ignore())
                .ForMember(dest => dest.Tasks, opt => opt.Ignore())
                .ForMember(dest => dest.ActivityPlots, opt => opt.Ignore());

            CreateMap<Activity, GetActivityDTO>()
                .ForMember(dest => dest.Tasks, opt => opt.MapFrom(src => src.Tasks))
                .ForMember(dest => dest.ParentActivity, opt => opt.MapFrom(src => src.ParentActivity));

            CreateMap<GetActivityDTO, Activity>()
                .ForMember(dest => dest.Tasks, opt => opt.MapFrom(src => src.Tasks))
                .ForMember(dest => dest.ParentActivity, opt => opt.MapFrom(src => src.ParentActivity));

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

            CreateMap<CreatePlotDTO, Plot>()
                .ForMember(dest => dest.PlotId, opt => opt.Ignore())
                .ForMember(dest => dest.ActivityPlots, opt => opt.Ignore());

            // Mapping from Plot to CreatePlotDTO
            CreateMap<Plot, CreatePlotDTO>();

            // Mapping from Plot to GetPlotDTO
            CreateMap<Plot, GetPlotDTO>();

            // Mapping from Activity to GetActivityDTO
            CreateMap<Activity, GetActivityDTO>()
                .ForMember(dest => dest.Request, opt => opt.MapFrom(src => src.Request))
                .ForMember(dest => dest.ActivityType, opt => opt.MapFrom(src => src.ActivityType))
                .ForMember(dest => dest.Tasks, opt => opt.MapFrom(src => src.Tasks))
                .ForMember(dest => dest.Plots, opt => opt.MapFrom(src => src.ActivityPlots.Select(ap => ap.Plot)))
                .ForMember(dest => dest.ParentActivity, opt => opt.MapFrom(src => src.ParentActivity));

            // Mapping from GetActivityDTO to Activity
            CreateMap<GetActivityDTO, Activity>()
                .ForMember(dest => dest.ActivityId, opt => opt.Ignore())
                .ForMember(dest => dest.Request, opt => opt.Ignore())
                .ForMember(dest => dest.ActivityType, opt => opt.Ignore())
                .ForMember(dest => dest.Tasks, opt => opt.Ignore())
                .ForMember(dest => dest.ActivityPlots, opt => opt.Ignore())
                .ForMember(dest => dest.ParentActivity, opt => opt.MapFrom(src => src.ParentActivity));

            // Mapping from GetPlotDTO to Plot
            CreateMap<GetPlotDTO, Plot>()
                .ForMember(dest => dest.PlotId, opt => opt.Ignore())
                .ForMember(dest => dest.ActivityPlots, opt => opt.Ignore());

            // Mapping from Activity_PlotRelashionship to GetActivity_PlotRelashionshipDTO
            CreateMap<Activity_PlotRelashionship, GetActivity_PlotRelashionshipDTO>()
                .ForMember(dest => dest.Activity, opt => opt.MapFrom(src => src.Activity))
                .ForMember(dest => dest.Plot, opt => opt.MapFrom(src => src.Plot));

            // Mapping from GetActivity_PlotRelashionshipDTO to Activity_PlotRelashionship
            CreateMap<GetActivity_PlotRelashionshipDTO, Activity_PlotRelashionship>()
                .ForMember(dest => dest.Activity, opt => opt.Ignore())
                .ForMember(dest => dest.Plot, opt => opt.Ignore());

            // Mapping from CreateActivity_PlotRelashionshipDTO to Activity_PlotRelashionship
            CreateMap<CreateActivity_PlotRelashionshipDTO, Activity_PlotRelashionship>()
                .ForMember(dest => dest.ActivityId, opt => opt.MapFrom(src => src.Activity.ActivityId))
                .ForMember(dest => dest.PlotId, opt => opt.MapFrom(src => src.Plot.PlotId))
                .ForMember(dest => dest.Activity, opt => opt.Ignore())
                .ForMember(dest => dest.Plot, opt => opt.Ignore());

            CreateMap<CreateOwnerDTO, Owner>();

            // Map Owner to GetOwnerDTO
            CreateMap<Owner, GetOwnerDTO>();

            CreateMap<CreateDocumentOfOwnershipDTO, DocumentOfOwnership>();

            // Map Owner to GetOwnerDTO
            CreateMap<DocumentOfOwnership, GetDocumentOfOwnershipDTO>();

            CreateMap<CreatePlot_DocumentOfOwnershipRelashionshipDTO, Plot_DocumentOfOwnershipRelashionship>();

            // Map Plot_DocumentOfOwnershipRelashionship to GetPlot_DocumentOfOwnershipRelashionshipDTO
            CreateMap<Plot_DocumentOfOwnershipRelashionship, GetPlot_DocumentOfOwnershipRelashionshipDTO>()
                .ForMember(dest => dest.Plot, opt => opt.MapFrom(src => src.Plot))
                .ForMember(dest => dest.documentOfOwnership, opt => opt.MapFrom(src => src.documentOfOwnership));

            CreateMap<CreateDocumentOfOwnership_OwnerRelashionshipDTO, DocumentOfOwnership_OwnerRelashionship>();

            // Map DocumentOfOwnership_OwnerRelashionship to GetDocumentOfOwnership_OwnerRelashionshipDTO
            CreateMap<DocumentOfOwnership_OwnerRelashionship, GetDocumentOfOwnership_OwnerRelashionshipDTO>()
                .ForMember(dest => dest.Document, opt => opt.MapFrom(src => src.Document))
                .ForMember(dest => dest.Owner, opt => opt.MapFrom(src => src.Owner));

            CreateMap<CreateDocumentPlot_DocumentOwnerRelashionshipDTO, DocumentPlot_DocumentOwnerRelashionship>();

            // Map DocumentPlot_DocumentOwnerRelashionship to GetDocumentPlot_DocumentOwnerRelashionshipDTO
            CreateMap<DocumentPlot_DocumentOwnerRelashionship, GetDocumentPlot_DocumentOwnerRelashionshipDTO>()
                .ForMember(dest => dest.DocumentPlot, opt => opt.MapFrom(src => src.DocumentPlot))
                .ForMember(dest => dest.DocumentOwner, opt => opt.MapFrom(src => src.DocumentOwner));

            CreateMap<GetPlotDTO, Plot>()
            .ForMember(dest => dest.PlotId, opt => opt.MapFrom(src => src.PlotId))
            .ForMember(dest => dest.PlotNumber, opt => opt.MapFrom(src => src.PlotNumber))
            .ForMember(dest => dest.RegulatedPlotNumber, opt => opt.MapFrom(src => src.RegulatedPlotNumber))
            .ForMember(dest => dest.neighborhood, opt => opt.MapFrom(src => src.neighborhood))
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
            .ForMember(dest => dest.Municipality, opt => opt.MapFrom(src => src.Municipality))
            .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Street))
            .ForMember(dest => dest.StreetNumber, opt => opt.MapFrom(src => src.StreetNumber))
            .ForMember(dest => dest.designation, opt => opt.MapFrom(src => src.designation))
            .ForMember(dest => dest.locality, opt => opt.MapFrom(src => src.locality))
            // Ignoring collections that are not present in the DTO
            .ForMember(dest => dest.PlotDocuments, opt => opt.Ignore())
            .ForMember(dest => dest.ActivityPlots, opt => opt.Ignore());

            CreateMap<CreateFileDTO, Files>();
        }
    }
}
