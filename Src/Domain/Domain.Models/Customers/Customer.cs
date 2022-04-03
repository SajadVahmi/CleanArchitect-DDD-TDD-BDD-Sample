﻿using Domain.Models.Contracts.DomainServices;
using Framework.Domain.Clock;
using Framework.Domain.Entities;
using Framework.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Customers
{
    public class Customer:AggregateRoot<CustomerId>
    {
        protected Customer()
        {

        }
        protected Customer(Guid id, string firstname, string lastname, Email email, IClock clock)
        {
            Id = CustomerId.FromGuid(id);
            Name = FullName.Create(firstname, lastname);
           
           
            RegisterDate = clock.Now();


        }

        public static async Task<Customer> Create(Guid id, string firstname, string lastname, string email, IClock clock,ICustomerDomainService customerDomainService)
        {
            Email emailObject= Email.Create(email);
            bool customerExistWithEmail = customerDomainService.ExistWithEmailAsync(emailObject).Result;
            if (customerExistWithEmail)
                throw new CustomerExistWithCurrentEmailException();
            return new Customer(id, firstname, lastname, emailObject, clock);
        }

        public FullName Name { get; protected set; }
        public Email Email { get; protected set; }
        public DateTime RegisterDate { get; protected set; }
        
    }
}
