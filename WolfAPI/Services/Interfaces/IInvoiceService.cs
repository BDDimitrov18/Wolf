using DTOS.DTO;

namespace WolfAPI.Services.Interfaces
{
    public interface IInvoiceService
    {
        public Task<GetInvoiceDTO> Add(CreateInvoiceDTO invoiceDTO, string clientId);

        public Task<bool> EditInvoice(GetInvoiceDTO invoiceDTO, string clientId);

        public Task<bool> DeleteInvoices(List<GetInvoiceDTO> invoiceDTOs, string clientId);
    }
}
