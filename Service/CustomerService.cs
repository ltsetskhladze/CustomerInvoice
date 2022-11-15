using AutoMapper;
using Domain;
using Dtos;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CustomerService :  ICustomerService
    {
        private readonly IMapper _mapper;
        protected readonly IRepositoryWrapper _repositoryWrapper;

        public CustomerService(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            _mapper = mapper;
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<CustomerDto>> GetCustomersAsync(int pageNumber, int pageSize)
        {
            try
            {
                var data = await _repositoryWrapper.Customer.FindAll()
                        .OrderBy(x => x.Id)
                        .Skip(pageNumber * pageSize)
                        .Take(pageSize).ToListAsync();
                var result = _mapper.Map<List<CustomerDto>>(data);
                return result;
            }
            catch (Exception)
            {
                //TODO:log exception
                throw;
            }
        }
    }
}
