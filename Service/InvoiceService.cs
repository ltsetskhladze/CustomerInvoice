using Domain.Entities;
using Domain;
using Microsoft.EntityFrameworkCore;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Repository;
using Dtos;
using Repository.Interfaces;

namespace Service
{
    public class InvoiceService :  IInvoiceService
    {
        private readonly IMapper _mapper;
        protected readonly IRepositoryWrapper _repositoryWrapper;

        public InvoiceService(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            _mapper = mapper;
            _repositoryWrapper = repositoryWrapper;
        }

        /// <summary>
        /// Get all invoice
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns>Invoice list</returns>
        public async Task<List<InvoiceDto>> GetInvoicesAsync(int pageNumber, int pageSize)
        {
            try
            {
                var data = await _repositoryWrapper.Invoice.FindAll()
                    .OrderBy(x => x.Id)
                    .Skip(pageNumber * pageSize)
                    .Take(pageSize).ToListAsync();
                var result = _mapper.Map<List<Invoice>, List<InvoiceDto>>(data);
                return result;
            }
            catch (Exception)
            {
                //TODO:log exception
                throw;
            }
        }

        /// <summary>
        /// Create invoice
        /// </summary>
        /// <param name="model">Invoice Model</param>
        /// <returns>Created invoice Id</returns>
        public async Task<int> CreateInvoiceAsync(InvoiceDto model)
        {
            try
            {
                var invoice = _mapper.Map<Invoice>(model);
                _repositoryWrapper.InvoiceLog.Create(new InvoiceLog() { Date = DateTime.Now, Invoice = invoice, Description = "Invoice created" });
                _repositoryWrapper.Invoice.Create(invoice);
                await _repositoryWrapper.Save();
                return invoice.Id;
            }
            catch (Exception)
            {
                //TODO:log exception
                throw;
            }
        }

        /// <summary>
        /// Update invoice
        /// </summary>
        /// <param name="model">Invoice Model</param>
        /// <returns></returns>
        public async Task<int> UpdateInvoiceAsync(InvoiceDto model)
        {
            try
            {
                var invoice = _repositoryWrapper.Invoice.Find(x => x.Id == model.Id);
                if (invoice == null)
                {
                    return -1;
                }
                invoice.Amount = model.Amount;
                invoice.CCY = model.CCY;
                invoice.Status = model.Status;
                invoice.Description = model.Description;
                invoice.DueDate = model.DueDate;
                _repositoryWrapper.InvoiceLog.Create(new InvoiceLog() { Date = DateTime.Now, Invoice = invoice, Description = "Invoice updated" });
                await _repositoryWrapper.Save();
                return invoice.Id;
            }
            catch (Exception)
            {
                //TODO:log exception
                throw;
            }
        }
    }
}