using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediatRSample.Domain
{
    public class OrderItem : IEntity
    {
        public int Id { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
