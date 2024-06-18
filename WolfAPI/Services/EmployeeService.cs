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

        private readonly EmployeeModelRepository _employeeRepository;
        private readonly Mapper _mapper;

        public EmployeeService(IEmployeeModelRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository as EmployeeModelRepository;
            _mapper = mapper as Mapper;
        }

        public void Add(CreateEmployeeDTO employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
            _employeeRepository.Add(employee);
        }
    }
}
