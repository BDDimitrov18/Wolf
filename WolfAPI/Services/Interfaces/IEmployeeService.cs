using DTOS.DTO;


namespace WolfAPI.Services.Interfaces
{
    public interface IEmployeeService
    {
        public Task<List<GetEmployeeDTO>> Add(List<CreateEmployeeDTO> employeeDto, string clientId);

        public IEnumerable<GetEmployeeDTO> GetAllEmployees();
    }
}
