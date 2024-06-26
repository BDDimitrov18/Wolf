using DTOS.DTO;


namespace WolfAPI.Services.Interfaces
{
    public interface IEmployeeService
    {
        public List<GetEmployeeDTO> Add(List<CreateEmployeeDTO> employeeDto);

        public IEnumerable<GetEmployeeDTO> GetAllEmployees();
    }
}
