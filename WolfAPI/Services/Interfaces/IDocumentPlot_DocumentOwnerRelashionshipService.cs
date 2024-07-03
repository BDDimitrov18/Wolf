using DTOS.DTO;

namespace WolfAPI.Services.Interfaces
{
    public interface IDocumentPlot_DocumentOwnerRelashionshipService
    {
        public Task<GetDocumentPlot_DocumentOwnerRelashionshipDTO> CreatePlotOwner(CreateDocumentPlot_DocumentOwnerRelashionshipDTO relashionshipDTO);
        public Task<GetDocumentPlot_DocumentOwnerRelashionshipDTO> FindById(int id);
    }
}
