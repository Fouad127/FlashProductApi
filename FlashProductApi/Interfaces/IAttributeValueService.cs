using FlashProductApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlashProductApi.Interfaces
{
    public interface IAttributeValueService
    {
        Task<ProductAttributeValue> AddProductAttributeValue(ProductAttributeValue attribute);
        Task<ProductAttributeValue> EditProductAttributeValue(ProductAttributeValue attribute);
        Task<ProductAttributeValue> DeleteProductAttributeValue(ProductAttributeValue attribute);
    }
}
