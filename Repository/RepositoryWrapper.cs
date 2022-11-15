using Domain;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private CustomerInvoiceContext _customerInvoiceContext;
        private ICustomerRepository _customer;
        private IInvoiceLogRepository _invoiceLog;
        private IInvoiceRepository _invoice;

        public ICustomerRepository Customer
        {
            get
            {
                if (_customer == null)
                {
                    _customer = new CustomerRepository(_customerInvoiceContext);
                }
                return _customer;
            }
        }
        public IInvoiceLogRepository InvoiceLog
        {
            get
            {
                if (_invoiceLog == null)
                {
                    _invoiceLog = new InvoiceLogRepository(_customerInvoiceContext);
                }
                return _invoiceLog;
            }
        }
        public IInvoiceRepository Invoice
        {
            get
            {
                if (_invoice == null)
                {
                    _invoice = new InvoiceRepository(_customerInvoiceContext);
                }
                return _invoice;
            }
        }
        public RepositoryWrapper(CustomerInvoiceContext customerInvoiceContext)
        {
            _customerInvoiceContext = customerInvoiceContext;
        }
        public async Task Save()
        {
            await _customerInvoiceContext.SaveChangesAsync();
        }
    }
}
