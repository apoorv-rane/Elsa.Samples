using AutoMapper;
using InvoiceCustomerApi.Entities;
using InvoiceCustomerApi.IRepositories;
using InvoiceCustomerApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceCustomerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceRepository _invoicerepo;
        private readonly IMapper _mapper;
        public InvoiceController(IInvoiceRepository invoicerepo, IMapper mapper)
        {
            _invoicerepo = invoicerepo;
            _mapper = mapper;
        }
        [HttpPost("AddInvoice")]
        public async Task<Invoice> Create(InvoiceDto invoice)
        {
            invoice.Date = DateTime.Now.Date;
            var invoicet = _mapper.Map<Invoice>(invoice);
            var invoices = await _invoicerepo.AddInvoice(invoicet);
            return invoices;
        }
        [HttpPut("UpdateInvoice")]
        public async Task<ActionResult> Update(Invoice invoice)
        {
            invoice.IsInvoicePaid = true;
            _mapper.Map(invoice, typeof(InvoiceDto), typeof(Invoice));
            await _invoicerepo.UpdateInvoice(invoice);
            return Ok();
        }
    }
}
