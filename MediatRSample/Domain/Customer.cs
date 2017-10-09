using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediatRSample.Domain
{
    public class Customer : IEntity
    {
        [Column("CustomerID")]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        [Column("FirstName")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Full Name")]
        //[Computed]
        public string FullName => LastName + ", " + FirstName;
        public int AddressID { get; set; }
        public virtual Address Address { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
