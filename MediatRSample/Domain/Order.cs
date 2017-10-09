using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediatRSample.Domain
{
    public class Order : IEntity
    {
        [Column("OrderID")]
        public int Id { get; set; }
        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }
        public int AddressID { get; set; }
        public virtual Address DispatchAddress { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Shipped Date")]
        public DateTime? ShippedDate { get; set; }
        public OrderStatus Status { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    }
}
