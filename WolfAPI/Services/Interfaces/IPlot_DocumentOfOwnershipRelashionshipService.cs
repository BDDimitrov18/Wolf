using DTOS.DTO;

namespace WolfAPI.Services.Interfaces
{
    public interface IPlot_DocumentOfOwnershipRelashionshipService
    {
        public Task<GetPlot_DocumentOfOwnershipRelashionshipDTO> createPlotDocument(CreatePlot_DocumentOfOwnershipRelashionshipDTO relashionshipDTO);

    }
}
