using DTOS.DTO;

namespace WolfAPI.Services.Interfaces
{
    public interface IStarRequest_EmployeeRelashionshipService
    {
        public Task<GetstarRequest_EmployeeRelashionshipDTO> add(CreateStarRequest_EmployeeRelashionshipDTO createRelashionshipDTO);
        public Task<bool> Delete(GetstarRequest_EmployeeRelashionshipDTO relashionshipDTO);

        public Task<List<GetstarRequest_EmployeeRelashionshipDTO>> GetByEmployeeID(GetEmployeeDTO employeeDTO);
    }
}
