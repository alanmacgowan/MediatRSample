using MediatRSample.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediatRSample.Infrastructure
{
    public static class DbInitializer
    {
        public static void Initialize(OrderProcessingContext context)
        {
            context.Database.EnsureCreated();

            if (context.Customers.Any())
            {
                return;   // DB has been seeded
            }

            var customers = new Customer[]
            {
            new Customer{FirstName="Juan",LastName="Perez",Email="juanperez@lalal.com", Address = new Address {City="CABA", County = "Buenos Aires", PostCode = "BSHD66D", Street="Calle 12" } },
            new Customer{FirstName="Jose",LastName="Pareas",Email="jose1@lalal.com", Address = new Address {City="Rosario", County = "Santa Fe", PostCode = "DDSS33", Street="Calle 22" }},
            new Customer{FirstName="Pablo",LastName="Lopez",Email="xxxxx@xxxx.com", Address = new Address {City="CABA", County = "Buenos Aires", PostCode = "344DFDFG", Street="Calle 24" }},
            new Customer{FirstName="Carlos",LastName="Gonzalez",Email="Gonzalez@hotmail.com", Address = new Address {City="CABA", County = "Buenos Aires", PostCode = "34444FDF", Street="Calle 3" }},
            };

            foreach (Customer c in customers)
            {
                context.Customers.Add(c);
            }

            context.SaveChanges();
        }
    }
}
