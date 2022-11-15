using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace CustomerInvoices.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("List")]
        public async Task<JsonResult> List(int page, int pageSize)
        {
            var result = await _customerService.GetCustomersAsync(page, pageSize);
            return Json(result);
        }
    }
}
