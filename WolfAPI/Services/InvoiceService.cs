using AutoMapper;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.Interfaces;
using DTOS.DTO;
using WolfAPI.Services.Interfaces;

namespace WolfAPI.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceModelRepository _invoiceModelRepository;
        private readonly IWebSocketService _webSocketService;
        private readonly IMapper _mapper;

        public InvoiceService(IInvoiceModelRepository invoiceModelRepository, IMapper mapper, IWebSocketService webSocketService)
        {
            _invoiceModelRepository = invoiceModelRepository;
            _mapper = mapper;
            _webSocketService = webSocketService;
        }

        public async Task<GetInvoiceDTO> Add(CreateInvoiceDTO invoiceDTO, string clientId) {
            Invoice invoice = _mapper.Map<Invoice>(invoiceDTO);
            invoice =  await _invoiceModelRepository.Add(invoice);

            var updateNotification = new UpdateNotification<GetInvoiceDTO>
            {
                OperationType = "Create",
                EntityType = "GetInvoiceDTO",
                UpdatedEntity = _mapper.Map<GetInvoiceDTO>(invoice)
            };
            await _webSocketService.SendMessageToRolesAsync(updateNotification, clientId, "admin", "user");
            return _mapper.Map<GetInvoiceDTO>(invoice);
        }

        public async Task<bool> EditInvoice(GetInvoiceDTO invoiceDTO, string clientId) {
            bool result = await _invoiceModelRepository.EditInvoiceAsync(_mapper.Map<Invoice>(invoiceDTO));
            var updateNotification = new UpdateNotification<GetInvoiceDTO>
            {
                OperationType = "Edit",
                EntityType = "GetInvoiceDTO",
                UpdatedEntity = invoiceDTO
            };
            await _webSocketService.SendMessageToRolesAsync(updateNotification, clientId, "admin", "user");
            return result;
        }

        public async Task<bool> DeleteInvoices(List<GetInvoiceDTO> invoiceDTOs, string clientId) {
            List<Invoice> invoices = new List<Invoice>();
            foreach(var invoice in invoiceDTOs) {
                invoices.Add(_mapper.Map<Invoice>(invoice));
            }
            bool result = await _invoiceModelRepository.DeleteInvoices(invoices);
            if (result) {
                var updateNotification = new UpdateNotification<List<GetInvoiceDTO>>
                {
                    OperationType = "Delete",
                    EntityType = "List<GetInvoiceDTO>",
                    UpdatedEntity = invoiceDTOs
                };
                await _webSocketService.SendMessageToRolesAsync(updateNotification, clientId, "admin", "user");
            }
            return result;
        }
    }
}
