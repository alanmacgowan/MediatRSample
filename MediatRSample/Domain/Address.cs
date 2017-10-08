using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediatRSample.Domain
{
    public class Address : IEntity
    {
        [Column("AddressID")]
        public int Id { get; set; }
        [Required]
        [StringLength(70)]
        public string Street { get; set; }
        [StringLength(50)]
        public string City { get; set; }
        [StringLength(50)]
        public string County { get; set; }
        public string PostCode { get; set; }
    }
}
