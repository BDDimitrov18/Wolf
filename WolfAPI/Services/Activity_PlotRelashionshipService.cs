using AutoMapper;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.Interfaces;
using DTOS.DTO;
using WolfAPI.Services.Interfaces;

namespace WolfAPI.Services
{
    public class Activity_PlotRelashionshipService : IActivity_PlotReleashionshipService
    {
        private readonly IActivity_PlotRelashionshipModelRepository _activityPlotModelRepository;
        private readonly IMapper _mapper;

        public Activity_PlotRelashionshipService(IActivity_PlotRelashionshipModelRepository activityPlotModelRepository, IMapper mapper)
        {
            _activityPlotModelRepository = activityPlotModelRepository;
            _mapper = mapper;
        }

        public async Task<List<GetActivity_PlotRelashionshipDTO>> CreateActivity_PlotRelashionship(List<CreateActivity_PlotRelashionshipDTO> relashionshipsDTO)
        {
            List<GetActivity_PlotRelashionshipDTO> activity_PlotRelashionshipDTOs = new List<GetActivity_PlotRelashionshipDTO>();
            List<GetPlotDTO> plots = new List<GetPlotDTO>();
            foreach(var relashionshipDTO in relashionshipsDTO)
            {
                var mappedRelashionship = _mapper.Map<Activity_PlotRelashionship>(relashionshipDTO);
                await _activityPlotModelRepository.Add(mappedRelashionship);
                activity_PlotRelashionshipDTOs.Add(_mapper.Map<GetActivity_PlotRelashionshipDTO>(mappedRelashionship));
            }

            return activity_PlotRelashionshipDTOs;
        }
    }
}
