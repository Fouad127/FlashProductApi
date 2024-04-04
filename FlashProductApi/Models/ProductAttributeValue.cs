using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlashProductApi.Models
{
    public class ProductAttributeValue
    {
        public int Id { get; set; }
        
        [StringLength(70)]
        public string Value { get; set; }

        //relation with attribute values (many values to one attribute )
        public int ProductAttributeId { get; set; }
        public ProductAttribute ProductAttribute { get; set; }
    }
}
