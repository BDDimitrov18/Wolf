using WolfAPI.DTO;

namespace WolfAPI.Services.Interfaces
{
    public interface IEmployeeService
    {
        public void Add(CreateEmployeeDTO employeeDto);
    }
}
