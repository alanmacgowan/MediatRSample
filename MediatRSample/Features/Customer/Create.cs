namespace MediatRSample.Features.Customer
{
    using AutoMapper;
    using FluentValidation;
    using MediatR;
    using MediatRSample.Domain;
    using MediatRSample.Infrastructure;
    using System.ComponentModel.DataAnnotations;

    public class Create
    {
        public class Command : IRequest
        {
            public int ID { get; set; }
            [Display(Name = "First Name")]
            public string FirstName { get; set; }
            [Display(Name = "Last Name")]
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

        public class Handler : IRequestHandler<Command>
        {
            private readonly OrderProcessingContext _db;

            public Handler(OrderProcessingContext db)
            {
                _db = db;
            }

            public void Handle(Command message)
            {
                var customer = Mapper.Map<Command, Customer>(message);

                _db.Customers.Add(customer);
            }
        }
    }

}
