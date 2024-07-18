using DTOS.DTO;


namespace WolfAPI.Services.Interfaces
{
    public interface IEmployeeService
    {
        public Task<List<GetEmployeeDTO>> Add(List<CreateEmployeeDTO> employeeDto);

        public IEnumerable<GetEmployeeDTO> GetAllEmployees();
    }
}
