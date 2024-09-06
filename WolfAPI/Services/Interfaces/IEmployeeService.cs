using DTOS.DTO;


namespace WolfAPI.Services.Interfaces
{
    public interface IEmployeeService
    {
        public Task<List<GetEmployeeDTO>> Add(List<CreateEmployeeDTO> employeeDto, string clientId);

        public IEnumerable<GetEmployeeDTO> GetAllEmployees();

        public  Task<GetEmployeeDTO> GetEmployeeById(int id);

        public Task<bool> DeleteEmployees(List<GetEmployeeDTO> employeeDTOs);

        public  Task<bool> EditEmployee(GetEmployeeDTO employeeDTO, string clientId);
    }
}