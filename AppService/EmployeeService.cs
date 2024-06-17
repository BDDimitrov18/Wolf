using AppService.Interfaces;
using AutoMapper;
using DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService
{
    public class EmployeeService: IEmployeeService
    {
        private readonly IEmployeeModelRepository _employeeModelRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeModelRepository employeeRepository, IMapper mapper)
        {
            _employeeModelRepository = employeeRepository;
            _mapper = mapper;
        }
    }
}
