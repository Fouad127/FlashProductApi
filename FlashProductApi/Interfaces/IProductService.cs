using FlashProductApi.Dtos;
using FlashProductApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlashProductApi.Interfaces
{
    public interface IProductService
    {
        Task<PagedList<ProductAddDto>> ShowAllProducts(int page = 1, int pageSize = 10);
        Task<ProductShowDto> ShowProductById(int id);
        Task<Product> FindById (int id);
        Task<Product> AddProduct(Product product);
        Task<Product> EditProduct(Product product);
        Task<Product> DeleteProduct(Product product);
        Task<List<ProductAddDto>> ShowProductsByCategory(int id);
    }
}
