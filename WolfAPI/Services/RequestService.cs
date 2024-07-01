using AutoMapper;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.Interfaces;
using DTOS.DTO;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using WolfAPI.Services.Interfaces;

namespace WolfAPI.Services
{
    public class RequestService: IRequestService
    {
        private readonly IRequestModelRepository _requestRepository;
        private readonly IClientModelRepository _clientRepository;
        private readonly IActivityModelRespository _activityModelRespository;
        private readonly IPlotModelRepository _plotModelRepository;
        private readonly IMapper _mapper;

        public RequestService(IRequestModelRepository requestRepository, IMapper mapper, IClientModelRepository clientRepository,
        IActivityModelRespository activityModelRespository, IPlotModelRepository plotModelRepository)
        {
            _requestRepository = requestRepository;
            _mapper = mapper;
            _clientRepository = clientRepository;
            _activityModelRespository = activityModelRespository;
            _plotModelRepository = plotModelRepository;
        }

        public async Task<List<RequestWithClientsDTO>> GetLinked(List<GetRequestDTO> requestsDTO)
        {
            List<RequestWithClientsDTO> requestWithClientsDTOs = new List<RequestWithClientsDTO>();
            foreach (var requestDTO in requestsDTO)
            {
                List<Client> clients = _clientRepository.GetLinked(_mapper.Map<Request>(requestDTO));
                List<Activity> activities = _activityModelRespository.FindLinkedActivity(_mapper.Map<Request>(requestDTO));
                
                List<GetClientDTO> getClientDTOs = new List<GetClientDTO>();
                List<GetActivityDTO> getActivityDTOs = new List<GetActivityDTO>();
                foreach (Client client in clients)
                {
                    getClientDTOs.Add(_mapper.Map<GetClientDTO>(client));
                }
                foreach (Activity activity in activities) {
                    getActivityDTOs.Add(_mapper.Map<GetActivityDTO>(activity));
                }
                foreach (var activityDto in getActivityDTOs) {
                    List<Plot> plots = await _plotModelRepository.GetLinkedPlotsToActivty(activityDto.ActivityId);
                    List<GetPlotDTO> plotDTOs = new List<GetPlotDTO>();
                    foreach (var plot in plots) {
                        plotDTOs.Add(_mapper.Map<GetPlotDTO>(plot));
                    }
                    activityDto.Plots = plotDTOs;
                }

                RequestWithClientsDTO requestLink = new RequestWithClientsDTO()
                {
                    requestDTO = requestDTO,
                    clientDTOs = getClientDTOs,
                    activityDTOs = getActivityDTOs
                };
                requestWithClientsDTOs.Add(requestLink);
            }
            
            return requestWithClientsDTOs;
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
