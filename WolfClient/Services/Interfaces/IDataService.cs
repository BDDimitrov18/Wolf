using DTOS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WolfClient.Services.Interfaces
{
    public interface IDataService
    {
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
    }
}
