using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using MediatR;
using MediatRSample.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MediatRSample.Features.Customer
{
    public class Edit
    {
        public class Query : IRequest<Command>
        {
            public int? Id { get; set; }
        }

        public class QueryValidator : AbstractValidator<Query>
        {
            public QueryValidator()
            {
                RuleFor(m => m.Id).NotNull();
            }
        }

        public class Command : IRequest
        {
            public int ID { get; set; }
            [Display(Name = "First Name")]
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
        }

        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(m => m.LastName).NotNull().Length(1, 50);
                RuleFor(m => m.FirstName).NotNull().Length(1, 50);
                RuleFor(m => m.Email).NotNull();
            }
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
                //return await _db.Customers.Where(s => s.Id == message.Id).ProjectToSingleOrDefaultAsync<Command>();
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

                Mapper.Map(message, customer);
            }
        }
    }
}
