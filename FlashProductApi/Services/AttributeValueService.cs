using FlashProductApi.Data;
using FlashProductApi.Interfaces;
using FlashProductApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlashProductApi.Services
{
    public class AttributeValueService : IAttributeValueService
    {
        private readonly ApplicationDbContext _context;

        public AttributeValueService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ProductAttributeValue> AddProductAttributeValue(ProductAttributeValue attribute)
        {
            await _context.ProductAttributeValues.AddAsync(attribute);
            await _context.SaveChangesAsync();
            return attribute;
        }

        public async Task<ProductAttributeValue> DeleteProductAttributeValue(ProductAttributeValue attribute)
        {
            _context.Remove(attribute);
            await _context.SaveChangesAsync();
            return attribute;
        }

        public async Task<ProductAttributeValue> EditProductAttributeValue(ProductAttributeValue attribute)
        {
            _context.Update(attribute);
            await _context.SaveChangesAsync();
            return attribute;
        }
    }
}
