using DataAccessLayer.Models;
using DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class InvoiceModelRepository : IInvoiceModelRepository
    {
        private WolfDbContext _WolfDbContext { get; set; }

        public InvoiceModelRepository(WolfDbContext wolfDbContext)
        {
            _WolfDbContext = wolfDbContext;
        }

        public async Task<Invoice> Add(Invoice invoice) {
            await _WolfDbContext.Invoices.AddAsync(invoice);
            await _WolfDbContext.SaveChangesAsync();
            return invoice;
        }

        public async Task<bool> EditInvoiceAsync(Invoice updatedInvoice)
        {
            var existingInvoice = await _WolfDbContext.Invoices
                .FirstOrDefaultAsync(i => i.InvoiceId == updatedInvoice.InvoiceId);

            if (existingInvoice == null)
            {
                return false;
            }

            // Update only the necessary fields
            existingInvoice.number = updatedInvoice.number;
            existingInvoice.Sum = updatedInvoice.Sum;
            // Save changes to the database
            await _WolfDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteInvoices(List<Invoice> invoices)
        {
            // Check if the list of invoices is null or empty
            if (invoices == null || invoices.Count == 0)
            {
                return false;
            }

            try
            {
                // Extract InvoiceIds from the list of Invoice
                var invoiceIds = invoices.Select(i => i.InvoiceId).ToList();

                // Find the invoices that need to be deleted
                var invoicesToDelete = _WolfDbContext.Invoices.Where(i => invoiceIds.Contains(i.InvoiceId)).ToList();

                if (invoicesToDelete == null || invoicesToDelete.Count == 0)
                {
                    return false;
                }

                // Remove the invoices from the DbContext
                _WolfDbContext.Invoices.RemoveRange(invoicesToDelete);

                // Save changes to the database asynchronously
                await _WolfDbContext.SaveChangesAsync();

                return true; // Indicate that the operation was successful
            }
            catch (Exception ex)
            {
                // Log the exception (logging not shown here)
                // Handle the exception as needed

                return false; // Indicate that the operation failed
            }
        }

        public async Task<List<Invoice>> LinkedInvoices(Request request)
        {
            // Check if the request is null
            if (request == null)
            {
                return null;
            }

            try
            {
                // Find the invoices that have the same RequestId as the given request
                var invoices = await _WolfDbContext.Invoices
                    .Where(i => i.RequestId == request.RequestId)
                    .ToListAsync();

                return invoices; // Return the list of invoices
            }
            catch (Exception ex)
            {
                // Log the exception (logging not shown here)
                // Handle the exception as needed

                return null; // Return null to indicate failure
            }
        }
    }
}
