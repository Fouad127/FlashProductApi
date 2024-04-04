using FlashProductApi.Data;
using FlashProductApi.Dtos;
using FlashProductApi.Interfaces;
using FlashProductApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlashProductApi.Services
{
    public class ProductAttributeService : IProductAttributeService
    {
        private readonly ApplicationDbContext _context;

        public ProductAttributeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ProductAttribute> AddProductAttribute(ProductAttribute attribute)
        {
            await _context.ProductAttributes.AddAsync(attribute);
            await _context.SaveChangesAsync();
            return attribute;
        }

        public async Task<ProductAttribute> DeleteProductAttribute(ProductAttribute attribute)
        {
            _context.Remove(attribute);
            await _context.SaveChangesAsync();
            return attribute;
        }

        public async Task<ProductAttribute> EditProductAttribute(ProductAttribute attribute)
        {
            _context.Update(attribute);
            await _context.SaveChangesAsync();
            return attribute;
        }

        public async Task<PagedList<Product>> ShowAllProductAttributes(int page= 1 , int pageSize=10)
        {
            var list = await _context.Products.ToListAsync();
            var pagedList = new PagedList<Product>(list, list.Count(), page, pageSize);
            return pagedList;
        }

        public async Task<ProductAttributeShowDto> ShowProductAttributeById(int id)
        {
            var product = await _context.Products.FindAsync(id);
            var attributes = await _context.ProductAttributes
                .Where(p=>p.ProductId==id)
                .Include(v=>v.ProductAttributeValues)
                .ToListAsync();
            return new ProductAttributeShowDto
            {
                Product = product,
                ProductAttribute = attributes
            };
        }
    }
}
