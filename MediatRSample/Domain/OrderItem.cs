using System.ComponentModel.DataAnnotations;

namespace MediatRSample.Domain
{
    public class OrderItem : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Quantity")]
        public int Qty { get; set; }
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
