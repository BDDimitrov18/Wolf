using AutoMapper;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.Interfaces;
using DTOS.DTO;
using Microsoft.EntityFrameworkCore;
using WolfAPI.Services.Interfaces;

namespace WolfAPI.Services
{
    public class RequestService: IRequestService
    {
        private readonly IRequestModelRepository _requestRepository;
        private readonly IMapper _mapper;

        public RequestService(IRequestModelRepository requestRepository, IMapper mapper)
        {
            _requestRepository = requestRepository;
            _mapper = mapper;
        }

        public List<GetRequestDTO> Add(List<CreateRequestDTO> requestsDto)
        {
            List<GetRequestDTO> returnList = new List<GetRequestDTO>();
            List<Request> requests = new List<Request>();
            foreach (var requestDTO in requestsDto) { 
                var request = _mapper.Map<Request>(requestDTO);
                requests.Add(request);
            }
            
            _requestRepository.Add(requests);
            foreach (var request in requests)
            {
                var requestDTO = _mapper.Map<GetRequestDTO>(request);
                returnList.Add(requestDTO); 
            }
            return returnList;
        }

        public List<GetRequestDTO> GetAllRequest()
        {
            var requestsList = _requestRepository.GetAll();
            List<GetRequestDTO> createRequestsDTOs = new List<GetRequestDTO>();
            foreach (var request in requestsList)
            {
                var requestDTO = _mapper.Map<GetRequestDTO>(request);
                createRequestsDTOs.Add(requestDTO);
            }
            return createRequestsDTOs;
        }
    }
}
