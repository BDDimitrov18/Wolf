using AutoMapper;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using DataAccessLayer.Repositories.Interfaces;
using WolfAPI.DTO;
using WolfAPI.Services.Interfaces;

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
    }
}
