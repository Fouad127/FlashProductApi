using FlashProductApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FlashProductApi.Dtos
{
    public class ProductAttributeDto
    {
        public ProductAddDto Product { get; set; }
        public List<ProductAttributeAddDto> ProductAttribute { get; set; }
        public List<AttributeValuesDto> ProductAttributeValues { get; set; }
    }
    public class ProductShowDto
    {
        public ProductAddDto Product { get; set; }
        public List<ProductAttributeAddDto> ProductAttribute { get; set; }
    }

    public class ProductAttributeShowDto
    {
        public Product Product { get; set; }
        public List<ProductAttribute> ProductAttribute { get; set; }
    }

}
