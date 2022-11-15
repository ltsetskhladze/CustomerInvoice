using Domain.Entities;
using Domain;
using Repository.Interfaces;

namespace Repository
{
    public class InvoiceLogRepository : RepositoryBase<InvoiceLog>, IInvoiceLogRepository
    {
        public InvoiceLogRepository(CustomerInvoiceContext customerInvoiceContext)
            : base(customerInvoiceContext)
        {
        }
    }
}
