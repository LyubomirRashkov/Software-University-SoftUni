using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebShopDemo.Core.Data.Models
{
    [Comment("Products to sell")]
    public class Product
    {
        [Comment("Unique identifier")]
        [Key]
        public Guid Id { get; set; }

        [Comment("Product name")]
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Comment("Product price")]
        public decimal Price { get; set; }

        [Comment("Products in stock")]
        public int Quantity { get; set; }

        [Comment("Product is active")]
        public bool IsActive { get; set; } = true;
    }
}
