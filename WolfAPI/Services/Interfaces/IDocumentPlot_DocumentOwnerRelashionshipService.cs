using DTOS.DTO;

namespace WolfAPI.Services.Interfaces
{
    public interface IDocumentPlot_DocumentOwnerRelashionshipService
    {
        public Task<GetDocumentPlot_DocumentOwnerRelashionshipDTO> CreatePlotOwner(CreateDocumentPlot_DocumentOwnerRelashionshipDTO relashionshipDTO, string clientId);
        public Task<GetDocumentPlot_DocumentOwnerRelashionshipDTO> FindById(int id);
        public List<GetDocumentPlot_DocumentOwnerRelashionshipDTO> GetLinkedByPlots(List<GetPlotDTO> getPlots);

        public Task<bool> deletePlotOwnerRelashionships(List<GetDocumentPlot_DocumentOwnerRelashionshipDTO> relashionshipDTOs, string clientId);

        public Task<bool> editDocument(GetDocumentPlot_DocumentOwnerRelashionshipDTO documentDTO, string clientId);

        public Task<List<GetDocumentPlot_DocumentOwnerRelashionshipDTO>> FetchLinkedRelashionships(GetPlotDTO plotDTO);
    }
}
