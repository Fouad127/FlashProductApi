using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlashProductApi.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [StringLength(70)]
        public string EnName { get; set; }
        [StringLength(100)]
        public string ArName { get; set; }
        [Required]
        public decimal Price { get; set; }
        public int Duration { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        [Required]
        public DateTime StartDate { get; set; }

        //relation with category (many product to one category )
        public int CategoryId { get; set; }
        public Category Category { get; set; }
  
        //relation with product attribute (one product to many attribute)
        public List<ProductAttribute> ProductAttributes { get; set; }
    }
}
