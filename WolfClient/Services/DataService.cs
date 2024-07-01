using DTOS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WolfClient.Services.Interfaces;
using WolfClient.ViewModels;

namespace WolfClient.Services
{
    public class DataService : IDataService
    {

        
        private List<RequestWithClientsDTO> _fetchedLinkedClients { get; set; }
        private GetRequestDTO _selectedRequest { get; set; }
        private List<GetClientDTO> _clientDTOs { get; set; }

        private List<GetEmployeeDTO> _employeeDTOs { get; set; }

        private List<GetActivityTypeDTO> _activityTypesDTOs { get; set; }

        private List<EKTVIewModel> _ektViewModels { get; set; }


        public DataService()
        {
            _fetchedLinkedClients = new List<RequestWithClientsDTO>();
            _clientDTOs = new List<GetClientDTO>();
            _employeeDTOs = new List<GetEmployeeDTO>();
        }

        public List<EKTVIewModel> GetEKTViewModels() {
            return _ektViewModels;
        }

        public void SetEKTViewModels(List<EKTVIewModel> listEKT) {
            _ektViewModels = listEKT;
        }

        public void SetFetchedLinkedRequests(List<RequestWithClientsDTO> linkedRequests) {
            _fetchedLinkedClients = linkedRequests;
        }

        public List<RequestWithClientsDTO> GetFetchedLinkedRequests() { 
            return _fetchedLinkedClients;
        }

        public void AddSingleRequest(RequestWithClientsDTO linkedRequest) {
            _fetchedLinkedClients.Add(linkedRequest);
        }

        public void AddMultipleRequests(List<RequestWithClientsDTO> linkedRequests) {
            _fetchedLinkedClients.AddRange(linkedRequests);
        }

        public void SetActivityTypes(List<GetActivityTypeDTO> activityTypeDTOs)
        {
            _activityTypesDTOs = activityTypeDTOs;
        }

        public List<GetActivityTypeDTO> GetActivityTypeDTOs() {
            return _activityTypesDTOs;
        }

        public List<GetEmployeeDTO> GetEmployees() {
            return _employeeDTOs;
        }

        public void SetEmployees(List<GetEmployeeDTO> employees) { 
            _employeeDTOs = employees;    
        }

        public void AddSingleEmployee(GetEmployeeDTO employeeDTO) {
            _employeeDTOs.Add(employeeDTO);
        }

        public void AddMultipleEmployees(List<GetEmployeeDTO> employeeDTOs) {
            _employeeDTOs.AddRange(employeeDTOs);
        }

        public void SetSelectedRequest(GetRequestDTO getRequestDTO) { 
            _selectedRequest = getRequestDTO;
        }

        public GetRequestDTO GetSelectedRequest()
        {
            return _selectedRequest;
        }

        public void AddActivityToTheList(GetActivityDTO activityDTO) {
            var ChosenLink = _fetchedLinkedClients.Where(opt => opt.requestDTO.RequestId == _selectedRequest.RequestId).FirstOrDefault();
            ChosenLink.activityDTOs.Add(activityDTO);
        }

        public void ReplaceActivity(GetActivityDTO activityDTO) {
            var ChosenLink = _fetchedLinkedClients.Where(opt => opt.requestDTO.RequestId == _selectedRequest.RequestId).FirstOrDefault();
            int br = 0;
            foreach (GetActivityDTO link in ChosenLink.activityDTOs)
            {
                if (link.ActivityId == activityDTO.ActivityId) {
                    ChosenLink.activityDTOs[br] = activityDTO;
                    break;
                }
                br++;
            }
        }

        
    }
}
