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
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Category> DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if(category == null)
            {
                return category;
            }
            _context.Remove(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<PagedList<CategoryDto>> ShowAllCategories(int page = 1, int pageSize = 10)
        {
            var list = await _context.Categories
                .Select(c=> new CategoryDto { 
                        CategoryId = c.Id,
                        Name = c.Name
            }).ToListAsync();
            var pagedList = new PagedList<CategoryDto>(list, list.Count(), page, pageSize);
            return pagedList;
        }

        public async Task<Category> ShowCategoryById(int id)
        {
            return await _context.Categories.FindAsync(id);
        }
    }
}
