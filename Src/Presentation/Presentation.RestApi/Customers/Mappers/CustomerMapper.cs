using AutoMapper;
using Domain.Contracts.Customers.Dtos;
using Presentation.Facade.Customers.Dtos;
using Presentation.RestApi.Customers.Requests;
using Presentation.RestApi.Customers.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.RestApi.Customers.Mappers
{
    public  class CustomerMapper : Profile
    {
        public CustomerMapper()
        {
            CreateMap<RegisterCustomerRequest, RegisterCustomerDto>();
            CreateMap<RegisteredCustomerDto, RegisterCustomerResponse>();
        }
    }
    
}
