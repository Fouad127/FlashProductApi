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
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product> AddProduct(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> DeleteProduct(Product product)
        {
            _context.Remove(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> EditProduct(Product product)
        {
            _context.Update(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> FindById(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<PagedList<ProductAddDto>> ShowAllProducts(int page= 1 , int pageSize= 10)
        {
            var list = await _context.Products.Select(pro=> new ProductAddDto { 
                Price = pro.Price,
                EnName = pro.EnName,
                ArName = pro.ArName,
                CategoryId = pro.CategoryId,
                CreationDate = pro.CreationDate,
                Duration = pro.Duration,
                StartDate = pro.StartDate,
                Id = pro.Id
            }).ToListAsync();
            var pagedList = new PagedList<ProductAddDto>(list, list.Count(), page, pageSize);
            return pagedList;
        }

        public async Task<ProductShowDto> ShowProductById(int id)
        {
            var result = new ProductShowDto();
            var product = await _context.Products.FindAsync(id);

            var retProduct = await _context.Products.Select(pro => new ProductAddDto
            {
                Price = pro.Price,
                EnName = pro.EnName,
                ArName = pro.ArName,
                CategoryId = pro.CategoryId,
                CreationDate = pro.CreationDate,
                Duration = pro.Duration,
                StartDate = pro.StartDate,
                Id = pro.Id
            }).FirstOrDefaultAsync();


            var attributes = await _context.ProductAttributes
                .Where(p => p.ProductId == product.Id)
                .Include(v => v.ProductAttributeValues)                
                .ToListAsync();
            var listOfAtt = new List<ProductAttributeAddDto>();
            foreach (var item in attributes)
            {
                var p = new ProductAttributeAddDto
                {
                    Id = item.Id,
                    Title = item.Title,
                    ProductId = item.ProductId,
                };

                p.attributeValuesDtos = item.ProductAttributeValues
                    .Select(val => new AttributeValuesDto
                {
                    ProductAttributeId = p.Id,
                    Value = val.Value,
                    Id = val.Id
                }).ToList();
                listOfAtt.Add(p);
            }

            return new ProductShowDto
            {
                Product = retProduct,
                ProductAttribute = listOfAtt,
               // ProductAttributeValues = listOfVal
             };
        }

        public async Task<List<ProductAddDto>> ShowProductsByCategory(int id)
        {
            var list = await _context.Products
                .Where(p=>p.CategoryId==id)
                .Select(pro => new ProductAddDto
            {
                Price = pro.Price,
                EnName = pro.EnName,
                ArName = pro.ArName,
                CategoryId = pro.CategoryId,
                CreationDate = pro.CreationDate,
                Duration = pro.Duration,
                StartDate = pro.StartDate,
                Id = pro.Id
            }).ToListAsync();
            return list;
        }
    }
}
