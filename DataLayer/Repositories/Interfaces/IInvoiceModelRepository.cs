using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IInvoiceModelRepository
    {
        public Task<Invoice> Add(Invoice invoice);
        public Task<bool> EditInvoiceAsync(Invoice updatedInvoice);
        public Task<bool> DeleteInvoices(List<Invoice> invoices);
        public Task<List<Invoice>> LinkedInvoices(Request request);
    }
}
