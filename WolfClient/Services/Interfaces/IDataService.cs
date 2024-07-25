using DTOS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WolfClient.ViewModels;

namespace WolfClient.Services.Interfaces
{
    public interface IDataService
    {
        public List<GetRequestDTO> filterRequestByStatusSelfActivitiesAndTasks(List<GetRequestDTO> requestDTOs, string status);
        public List<GetRequestDTO> FilterRequestByWeekSelfActivitiesAndTasks(List<GetRequestDTO> requestDTOs);
        public List<GetRequestDTO> filterRequestByDaySelfActivitiesAndTasks(List<GetRequestDTO> requestDTOs);
        public List<GetRequestDTO> filterRequestsBySelfActivitiesAndTasks(List<GetRequestDTO> requestDTOs);
        public GetEmployeeDTO getLoggedEmployee();
        public void SetLoggedEmployee(GetEmployeeDTO employeeDTO);
        public GetPlotDTO getPlotFromPlotOwnerID(int plotOwnerId);
        public void EditPlot(GetPlotDTO plotDTO);
        public GetActivityDTO GetSelectedActivity();
        public void editClient(GetClientDTO clientDTO);
        public void SetEditedRequestClients(List<GetClientDTO> getClientDTOs, GetRequestDTO getRequestDTO);
        public void SetSelectedActivityViews(List<ActivityViewModel> activityViewModels);
        public List<GetClientDTO> getSelectedCLients();
        public void SetSelectedClients(List<GetClientDTO> getClients);
        public List<GetDocumentOfOwnershipDTO> GetDocumentsFromPlots(GetPlotDTO plot);
        public void setPlotOwnersRelashionships(List<GetDocumentPlot_DocumentOwnerRelashionshipDTO> relashionshipsDTO);
        public void SetFetchedLinkedRequests(List<RequestWithClientsDTO> linkedRequests);
        public List<GetClientDTO> getLinkedClients();
        public List<RequestWithClientsDTO> GetFetchedLinkedRequests();

        public void AddSingleRequest(RequestWithClientsDTO linkedRequest);


        public void AddMultipleRequests(List<RequestWithClientsDTO> linkedRequests);

        public void SetActivityTypes(List<GetActivityTypeDTO> activityTypeDTOs);

        public List<GetActivityTypeDTO> GetActivityTypeDTOs();

        public List<GetEmployeeDTO> GetEmployees();
        public void EditRequest(GetRequestDTO requestDTO);
        public void SetEmployees(List<GetEmployeeDTO> employees);

        public void AddSingleEmployee(GetEmployeeDTO employeeDTO);

        public void AddMultipleEmployees(List<GetEmployeeDTO> employeeDTOs);
        public void SetSelectedRequest(GetRequestDTO getRequestDTO);
        public GetRequestDTO GetSelectedRequest();

        public void AddActivityToTheList(GetActivityDTO activityDTO);

        public void ReplaceActivity(GetActivityDTO activityDTO);

        public List<EKTVIewModel> GetEKTViewModels();
        public void SetEKTViewModels(List<EKTVIewModel> listEKT);

        public RequestWithClientsDTO GetSelectedLinkedRequest();

        public List<GetPlotDTO> GetSelectedPlots();

        public void addPlotOwnerRelashionship(GetDocumentPlot_DocumentOwnerRelashionshipDTO relashionshipDTO);

        public List<GetPlotDTO> GetAllPlots();
        public List<GetDocumentPlot_DocumentOwnerRelashionshipDTO> GetLinkedPlotOwnerRelashionships();

        public List<GetDocumentOfOwnershipDTO> getAllDocuments();

        public void OnRequestDelete();

        public List<GetRequestDTO> getRequests();

        public void OnClientsRequestDelete();

        public List<GetTaskDTO> getTasksFromViewModel();
        public List<GetActivityDTO> OnTasksDelete(List<GetTaskDTO> taskDTOs);

        public void DeleteActivities(List<GetActivityDTO> activityDTOs);

        public List<GetPowerOfAttorneyDocumentDTO> GetPowerOfAttorneyFromPlots(GetPlotDTO plot);

        public void SetSelectedPlotsOnRequestMenu(List<GetPlotDTO> plots);

        public List<GetActivity_PlotRelashionshipDTO> getActivity_PlotRelashionshipDTOs(List<GetPlotDTO> plots);

        public List<GetPlotDTO> getSelectedPlotsOnRequestMenu();

        public void RemovePlots(List<GetPlotDTO> plots);
        public void SetSelectedOwnershipViewModelsRequestMenu(List<OwnershipViewModel> ownershipViewModels);
        public List<OwnershipViewModel> GetSelectedOwnershipViewModelsRequestMenu();
        public void RemovePlotOwnerRelashionships(List<GetDocumentPlot_DocumentOwnerRelashionshipDTO> relashionshipDTOs);

        public GetDocumentPlot_DocumentOwnerRelashionshipDTO GetPlotOwnerById(int id);

        public List<GetPowerOfAttorneyDocumentDTO> GetAllPowerOfAttorneys();

        public List<GetActivityDTO> GetSelectedActivities();

        public List<GetPlotDTO> GetSelectedPlotsFilterActivity(GetActivityDTO activityDTO);

        public List<GetDocumentPlot_DocumentOwnerRelashionshipDTO> GetLinkedPlotOwnerRelashionshipsFilterActivity(GetActivityDTO activityDTO);

        public void HandleWebSocketMessage(string message);

        public GetTaskDTO GetSelectedTask();

        public void editActivity(GetActivityDTO activityDTO);
        public void editTask(GetTaskDTO taskDTO);

        public GetOwnerDTO GetOwnerByEgn(string egn);

        public void EditOwner(GetOwnerDTO ownerDTO);
        public void EditDocument(GetDocumentOfOwnershipDTO documentDTO);

        public void EditPowerOfAttorney(GetPowerOfAttorneyDocumentDTO powerOfAttorneyDocumentDTO);
        public void EditPlotOwnerRelashionship(GetDocumentPlot_DocumentOwnerRelashionshipDTO relashionshipDTO);
    }
}
