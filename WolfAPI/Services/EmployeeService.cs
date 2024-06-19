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
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeModelRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public void Add(CreateEmployeeDTO employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
            _employeeRepository.Add(employee);
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
    }
}
