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
        public void setPlotOwnersRelashionships(List<GetDocumentPlot_DocumentOwnerRelashionshipDTO> relashionshipsDTO);
        public void SetFetchedLinkedRequests(List<RequestWithClientsDTO> linkedRequests);

        public List<RequestWithClientsDTO> GetFetchedLinkedRequests();

        public void AddSingleRequest(RequestWithClientsDTO linkedRequest);


        public void AddMultipleRequests(List<RequestWithClientsDTO> linkedRequests);

        public void SetActivityTypes(List<GetActivityTypeDTO> activityTypeDTOs);

        public List<GetActivityTypeDTO> GetActivityTypeDTOs();

        public List<GetEmployeeDTO> GetEmployees();

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

    }
}
