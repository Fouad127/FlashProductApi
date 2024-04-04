using FlashProductApi.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlashProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        public CategoriesController(ICategoryService categoryService, IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            return Ok(await _categoryService.ShowAllCategories());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _categoryService.ShowCategoryById(id);
            if(category == null)
            {
                return NotFound($"Not Category with this id {id}");
            }
            await _categoryService.DeleteCategory(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductsInCategory(int id)
        {
            return Ok(await _productService.ShowProductsByCategory(id));
        }
    }
}
