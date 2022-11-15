using AutoMapper;
using Domain.Entities;
using Dtos;

namespace CustomerInvoices.Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Invoice, InvoiceDto>().ReverseMap().ForMember(x => x.InvoiceLogs, x => x.Ignore());
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<InvoiceLog, InvoiceLogDto>().ReverseMap();
        }
    }
}
