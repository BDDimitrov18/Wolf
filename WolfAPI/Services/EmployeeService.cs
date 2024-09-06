using AutoMapper;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using DataAccessLayer.Repositories.Interfaces;
using WolfAPI.Services.Interfaces;
using DTOS.DTO;

namespace WolfAPI.Services
{
    public class EmployeeService : IEmployeeService
    {

        private readonly IEmployeeModelRepository _employeeRepository;
        private readonly IWebSocketService _webSocketService;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeModelRepository employeeRepository, IMapper mapper, IWebSocketService webSocketService)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _webSocketService = webSocketService;
        }

        public async Task<List<GetEmployeeDTO>> Add(List<CreateEmployeeDTO> employeeDto,string clientId)
        {
            List<GetEmployeeDTO> returnList = new List<GetEmployeeDTO>();
            List<Employee> employees = new List<Employee>();
            foreach (var employeeDTO in employeeDto)
            {
                var employee = _mapper.Map<Employee>(employeeDTO);
                employees.Add(employee);
            }

            _employeeRepository.Add(employees);

            foreach (var employee in employees)
            {
                var employeeDTO = _mapper.Map<GetEmployeeDTO>(employee);
                returnList.Add(employeeDTO);
            }

            var updateNotification = new UpdateNotification<List<GetEmployeeDTO>>
            {
                OperationType = "Create",
                EntityType = "List<GetEmployeeDTO>",
                UpdatedEntity = returnList
            };
            await _webSocketService.SendMessageToRolesAsync(updateNotification,clientId, "admin", "user");

            return returnList;
        }

        public IEnumerable<GetEmployeeDTO> GetAllEmployees() {
            var employeesList = _employeeRepository.GetAll();
            List<GetEmployeeDTO> createEmployeeDTOs = new List<GetEmployeeDTO>();
            foreach (var client in employeesList)
            {
                var employeeDTO = _mapper.Map<GetEmployeeDTO>(client);
                createEmployeeDTOs.Add(employeeDTO);
            }
            return createEmployeeDTOs;
        }

        public async Task<GetEmployeeDTO> GetEmployeeById(int id) {
           return _mapper.Map<GetEmployeeDTO>(await _employeeRepository.Get(id));
        }


        public async Task<bool> EditEmployee(GetEmployeeDTO employeeDTO, string clientId) { 
            Employee employee = _mapper.Map<Employee>(employeeDTO);
            bool result = await _employeeRepository.EditEmployee(employee);

            var updateNotification = new UpdateNotification<GetEmployeeDTO>
            {
                OperationType = "Edit",
                EntityType = "GetEmployeeDTO",
                UpdatedEntity = employeeDTO
            };
            await _webSocketService.SendMessageToRolesAsync(updateNotification, clientId, "admin", "user");
            return result;
        }
    }
}
