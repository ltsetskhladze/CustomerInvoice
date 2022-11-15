using Domain;
using Domain.Entities;
using Repository.Interfaces;

namespace Repository
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(CustomerInvoiceContext customerInvoiceContext)
            : base(customerInvoiceContext)
        {
        }
    }
}
