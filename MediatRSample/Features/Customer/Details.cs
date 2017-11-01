using AutoMapper;
using MediatR;
using MediatRSample.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MediatRSample.Features.Customer
{
    public class Details
    {
        public class Query : IRequest<Model>
        {
            public int Id { get; set; }
        }

        public class Model
        {
            public int ID { get; set; }
            [Display(Name = "First Name")]
            public string FirstName { get; set; }
            [Display(Name = "Last Name")]
            public string LastName { get; set; }
            public string Email { get; set; }
        }

        public class Handler : IAsyncRequestHandler<Query, Model>
        {
            private readonly OrderProcessingContext _db;

            public Handler(OrderProcessingContext db)
            {
                _db = db;
            }

            public async Task<Model> Handle(Query message)
            {
                var customer = await _db.Customers.Where(s => s.Id == message.Id).SingleOrDefaultAsync();
                return Mapper.Map(customer, new Model());
            }
        }
    }
}
