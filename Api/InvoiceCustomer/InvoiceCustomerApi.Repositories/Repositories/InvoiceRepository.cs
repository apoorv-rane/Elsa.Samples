using InvoiceCustomerApi.Entities;
using InvoiceCustomerApi.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCustomerApi.Repositories.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly DbContexts _context;

        public InvoiceRepository(DbContexts context)
        {
            _context = context;
        }
        public async Task<Invoice> AddInvoice(Invoice invoice)
        {
            await _context.Invoices.AddAsync(invoice);
            await _context.SaveChangesAsync();
            return invoice;
        }

        public async Task<IReadOnlyList<Invoice>> GetInvoice()
        {
            var invoice = await _context.Invoices.ToListAsync();
            return invoice;
        }

        public async Task UpdateInvoice(Invoice invoice)
        {
            _context.Entry(invoice).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
