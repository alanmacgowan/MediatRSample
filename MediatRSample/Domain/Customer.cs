using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MediatRSample.Domain
{
    public class Customer : Person
    {
        public int AddressId { get; set; }
        public virtual Address Address { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
