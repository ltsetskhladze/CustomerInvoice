using Domain;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System.Linq.Expressions;

namespace Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected CustomerInvoiceContext CustomerInvoiceContext { get; set; }
        public RepositoryBase(CustomerInvoiceContext customerInvoiceContext)
        {
            CustomerInvoiceContext = customerInvoiceContext;
        }
        public IQueryable<T> FindAll() => CustomerInvoiceContext.Set<T>().AsNoTracking();
        public T? Find(Expression<Func<T, bool>> expression) => CustomerInvoiceContext.Set<T>().FirstOrDefault(expression);
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
            CustomerInvoiceContext.Set<T>().Where(expression).AsNoTracking();
        public void Create(T entity) => CustomerInvoiceContext.Set<T>().Add(entity);
        public void Update(T entity) => CustomerInvoiceContext.Set<T>().Update(entity);
        public void Delete(T entity) => CustomerInvoiceContext.Set<T>().Remove(entity);
    }
}
