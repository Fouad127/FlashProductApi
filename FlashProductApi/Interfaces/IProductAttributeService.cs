using FlashProductApi.Dtos;
using FlashProductApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlashProductApi.Interfaces
{
    public interface IProductAttributeService
    {
        Task<PagedList<Product>> ShowAllProductAttributes(int page = 1, int pageSize = 10);
        Task<ProductAttributeShowDto> ShowProductAttributeById(int id);
        Task<ProductAttribute> AddProductAttribute(ProductAttribute attribute);
        Task<ProductAttribute> EditProductAttribute(ProductAttribute attribute);
        Task<ProductAttribute> DeleteProductAttribute(ProductAttribute attribute);
    }
}
