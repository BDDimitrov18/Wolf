using DataAccessLayer.Models;
using DTOS.DTO;

namespace WolfAPI.Services.Interfaces
{
    public interface IActivity_PlotReleashionshipService
    {
        public Task<List<GetActivity_PlotRelashionshipDTO>> CreateActivity_PlotRelashionship(List<CreateActivity_PlotRelashionshipDTO> relashionshipsDTO);

        public Task<bool> OnActivityDelete(Activity activity);

        public Task<bool> OnPlotRelashionshipRemove(List<GetActivity_PlotRelashionshipDTO> plotsDTO);

    }
}
