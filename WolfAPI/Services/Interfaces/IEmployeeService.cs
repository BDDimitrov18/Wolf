using DTOS.DTO;


namespace WolfAPI.Services.Interfaces
{
    public interface IEmployeeService
    {
        public void Add(CreateEmployeeDTO employeeDto);

        public IEnumerable<GetEmployeeDTO> GetAllEmployees();
    }
}
