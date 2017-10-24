using AutoMapper.QueryableExtensions;
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
    public class Index
    {
        public class Query : IRequest<Result>
        {
            public string SortOrder { get; set; }
            public string CurrentFilter { get; set; }
            public string SearchString { get; set; }
        }

        public class Result
        {
            public string CurrentSort { get; set; }
            public string NameSortParm { get; set; }
            public string FirstNameSortParm { get; set; }
            public string EmailSortParm { get; set; }
            public string CurrentFilter { get; set; }
            public string SearchString { get; set; }

            public IList<Model> Results { get; set; }
        }

        public class Model
        {
            public int ID { get; set; }
            [Display(Name = "First Name")]
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
        }

        public class QueryHandler : IAsyncRequestHandler<Query, Result>
        {
            private readonly OrderProcessingContext _db;

            public QueryHandler(OrderProcessingContext db)
            {
                _db = db;
            }

            public async Task<Result> Handle(Query message)
            {
                var model = new Result
                {
                    CurrentSort = message.SortOrder,
                    NameSortParm = String.IsNullOrEmpty(message.SortOrder) ? "name_desc" : "",
                    FirstNameSortParm = message.SortOrder == "FirstName" ? "firstname_desc" : "FirstName",
                    EmailSortParm = message.SortOrder == "Email" ? "email_desc" : "Email",
                };

                model.CurrentFilter = message.SearchString;
                model.SearchString = message.SearchString;

                var customers = from s in _db.Customers
                               select s;
                if (!String.IsNullOrEmpty(message.SearchString))
                {
                    customers = customers.Where(s => s.LastName.Contains(message.SearchString)
                                                   || s.FirstName.Contains(message.SearchString));
                }
                switch (message.SortOrder)
                {
                    case "name_desc":
                        customers = customers.OrderByDescending(s => s.LastName);
                        break;
                    case "FirstName":
                        customers = customers.OrderBy(s => s.FirstName);
                        break;
                    case "firstname_desc":
                        customers = customers.OrderByDescending(s => s.FirstName);
                        break;
                    case "Email":
                        customers = customers.OrderBy(s => s.Email);
                        break;
                    case "email_desc":
                        customers = customers.OrderByDescending(s => s.Email);
                        break;
                    default: // Name ascending 
                        customers = customers.OrderBy(s => s.LastName);
                        break;
                }

                model.Results = await customers.ProjectTo<Model>().ToListAsync();

                return model;
            }
        }

    }
}
