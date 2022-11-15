using Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IInvoiceService
    {
        Task<List<InvoiceDto>> GetInvoicesAsync(int pageNumber, int pageSize);
        Task<int> CreateInvoiceAsync(InvoiceDto model);
        Task<int> UpdateInvoiceAsync(InvoiceDto model);
    }
}
