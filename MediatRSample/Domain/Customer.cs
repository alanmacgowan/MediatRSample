using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediatRSample.Domain
{
    public class Customer : Person
    {
        public int AddressId { get; set; }
        public virtual Address Address { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
