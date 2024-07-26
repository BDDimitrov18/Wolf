using AutoMapper;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.Interfaces;
using DTOS.DTO;
using WolfAPI.Services.Interfaces;

namespace WolfAPI.Services
{
    public class StarRequest_EmployeeRelashionshipService : IStarRequest_EmployeeRelashionshipService
    {
        private readonly IStarRequest_EmployeeRelashionshipModelRepository _repository;
        private readonly IMapper _mapper;

        public StarRequest_EmployeeRelashionshipService(IStarRequest_EmployeeRelashionshipModelRepository repository,
            IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<GetstarRequest_EmployeeRelashionshipDTO> add(CreateStarRequest_EmployeeRelashionshipDTO createRelashionshipDTO)
        {
            // Map the Create DTO to the entity
            var relationshipEntity = _mapper.Map<starRequest_EmployeeRelashionship>(createRelashionshipDTO);

            // Add the new entity to the repository
            await _repository.AddAsync(relationshipEntity);


            // Map the newly created entity to the Get DTO
            var getRelationshipDTO = _mapper.Map<GetstarRequest_EmployeeRelashionshipDTO>(relationshipEntity);

            // Return the Get DTO
            return getRelationshipDTO;
        }

        public async Task<bool> Delete(GetstarRequest_EmployeeRelashionshipDTO relashionshipDTO)
        {
            // Map the Get DTO to the entity
            var relationshipEntity = _mapper.Map<starRequest_EmployeeRelashionship>(relashionshipDTO);

            // Use the repository to delete the relationship
            var result = await _repository.DeleteAsync(relationshipEntity);

            return result;
        }

        public async Task<List<GetstarRequest_EmployeeRelashionshipDTO>> GetByEmployeeID(GetEmployeeDTO employeeDTO)
        {
            // Map the GetEmployeeDTO to the Employee entity to get the ID
            var employeeEntity = _mapper.Map<Employee>(employeeDTO);

            // Query the repository to get the list of relationships
            var relationships = await _repository.GetByEmployeeID(employeeEntity.EmployeeId);

            // Map each relationship individually
            var relationshipDTOs = new List<GetstarRequest_EmployeeRelashionshipDTO>();
            foreach (var relationship in relationships)
            {
                var relationshipDTO = _mapper.Map<GetstarRequest_EmployeeRelashionshipDTO>(relationship);
                relationshipDTOs.Add(relationshipDTO);
            }

            // Return the list of DTOs
            return relationshipDTOs;
        }
    }
}
