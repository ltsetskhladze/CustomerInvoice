using Domain.Entities;
using Domain;
using Repository.Interfaces;

namespace Repository
{
    public class InvoiceRepository : RepositoryBase<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(CustomerInvoiceContext customerInvoiceContext)
            : base(customerInvoiceContext)
        {
        }
    }
}
