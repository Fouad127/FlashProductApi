using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlashProductApi.Dtos
{
    public class ProductAddDto
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
        public int CategoryId { get; set; }
    }
    public class ProductAttributeAddDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ProductId { get; set; }
        public List<AttributeValuesDto> attributeValuesDtos { get; set; }

    }
 
    public class AttributeValuesDto
    {
        public int Id { get; set; }

        [StringLength(70)]
        public string Value { get; set; }
        public int ProductAttributeId { get; set; }
    }
}
