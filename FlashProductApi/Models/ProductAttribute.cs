using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlashProductApi.Models
{
    public class ProductAttribute
    {
        public int Id { get; set; }
        public string Title { get; set; }

        //relation with product  (many attribute to one product )
        public int ProductId { get; set; }
        public Product Product { get; set; }

        //relation with attribute values (one attribute to many values)
        public List<ProductAttributeValue> ProductAttributeValues { get; set; }
    }
}
