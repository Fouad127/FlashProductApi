using FlashProductApi.Dtos;
using FlashProductApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlashProductApi.Interfaces
{
    public interface ICategoryService
    {
        Task<PagedList<CategoryDto>> ShowAllCategories(int page = 1, int pageSize = 12);
        Task<Category> ShowCategoryById(int id);
        Task<Category> DeleteCategory(int id);
    }
}
