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
    public class Delete
    {
        public class Query : IRequest<Command>
        {
            public int Id { get; set; }
        }

        public class Command : IRequest
        {
            public int ID { get; set; }
            [Display(Name = "First Name")]
            public string FirstName { get; set; }
            [Display(Name = "Last Name")]
            public string LastName { get; set; }
            public string Email { get; set; }
        }

        public class QueryHandler : IAsyncRequestHandler<Query, Command>
        {
            private readonly OrderProcessingContext _db;

            public QueryHandler(OrderProcessingContext db)
            {
                _db = db;
            }

            public async Task<Command> Handle(Query message)
            {
                var customer = await _db.Customers.Where(s => s.Id == message.Id).SingleOrDefaultAsync();
                return Mapper.Map(customer, new Command());
            }
        }

        public class CommandHandler : IAsyncRequestHandler<Command>
        {
            private readonly OrderProcessingContext _db;

            public CommandHandler(OrderProcessingContext db)
            {
                _db = db;
            }

            public async Task Handle(Command message)
            {
                var customer = await _db.Customers.FindAsync(message.ID);

                _db.Customers.Remove(customer);
            }
        }

    }

}
