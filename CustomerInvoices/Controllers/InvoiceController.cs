using Dtos;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace CustomerInvoices.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvoiceController : Controller
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpGet("List")]
        public async Task<JsonResult> List(int page, int pageSize)
        {
            var result = await _invoiceService.GetInvoicesAsync(page, pageSize);
            return Json(result);
        }

        [HttpPost("Create")]
        public async Task<JsonResult> Create(InvoiceDto model)
        {
            var result = await _invoiceService.CreateInvoiceAsync(model);
            return Json(result);
        }

        [HttpPut("Update")]
        public async Task<JsonResult> Update(InvoiceDto model)
        {
            var result = await _invoiceService.UpdateInvoiceAsync(model);
            return Json(result);
        }
    }
}
