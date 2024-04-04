using FlashProductApi.Dtos;
using FlashProductApi.Interfaces;
using FlashProductApi.Models;
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
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IProductAttributeService _productAttributeService;
        private readonly IAttributeValueService _attributeValueService;

        public ProductsController(IProductService productService,
            IProductAttributeService productAttributeService, 
            IAttributeValueService attributeValueService)
        {
            _productService = productService;
            _productAttributeService = productAttributeService;
            _attributeValueService = attributeValueService;
        }

        [HttpGet("showall")]
        public async Task<IActionResult> GetAllProducts(int page , int pageSize)
        {
            var list = await _productService.ShowAllProducts(page,pageSize);
            return Ok(list);
        }

        [HttpGet("detail/{id}")]
        public async Task<IActionResult> GetProductDetails (int id)
        {
            var product = await _productService.ShowProductById(id);
            return Ok(product);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddProduct(ProductAttributeDto attributeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(attributeDto);
            }

            var p = new Product
            {
                EnName = attributeDto.Product.EnName,
                ArName = attributeDto.Product.ArName,
                Price = attributeDto.Product.Price,
                StartDate = attributeDto.Product.StartDate,
                CategoryId = attributeDto.Product.CategoryId,
                Duration = attributeDto.Product.Duration
            };

            var product = await _productService.AddProduct(p);
            foreach (var customField in attributeDto.ProductAttribute)
            {
                var att = new ProductAttribute
                {
                    ProductId = product.Id,
                    Title = customField.Title,
                };
                await _productAttributeService.AddProductAttribute(att);
                foreach(var attVal in attributeDto.ProductAttributeValues)
                {
                    var proAttVal = new ProductAttributeValue
                    {
                        ProductAttributeId = att.Id,
                        Value = attVal.Value
                    };
                    await _attributeValueService.AddProductAttributeValue(proAttVal);
                }
            }
            var ret = _productService.ShowProductById(product.Id);
            return Ok(ret);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateProduct(int id , ProductAttributeDto attributeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(attributeDto);
            }

            if(id!=attributeDto.Product.Id)
            {
                return BadRequest("Invalid Product Id");
            }
            var prod = await _productService.FindById(id);
            if(prod == null)
            {
                return NotFound($"Not Product with this id {id}");
            }
            prod.Id = attributeDto.Product.Id;
            prod.EnName = attributeDto.Product.EnName;
            prod.ArName = attributeDto.Product.ArName;
            prod.Price = attributeDto.Product.Price;
            prod.StartDate = attributeDto.Product.StartDate;
            prod.CategoryId = attributeDto.Product.CategoryId;
            prod.Duration = attributeDto.Product.Duration;

            var product = await _productService.EditProduct(prod);
            foreach (var customField in attributeDto.ProductAttribute)
            {
                var att = new ProductAttribute
                {
                    ProductId = product.Id,
                    Title = customField.Title,
                    Id = customField.Id
                };
                await _productAttributeService.EditProductAttribute(att);
                foreach (var attVal in attributeDto.ProductAttributeValues)
                {
                    var proAttVal = new ProductAttributeValue
                    {
                        ProductAttributeId = att.Id,
                        Value = attVal.Value,
                        Id = attVal.Id
                    };
                    await _attributeValueService.EditProductAttributeValue(proAttVal);
                }
            }
            var ret = await _productService.ShowProductById(product.Id);
            return Ok(ret);
        }


        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var p = await _productService.FindById(id);
            if (p == null)
            {
                return NotFound($"Not Product with this id {id}");
            }

            var product = await _productService.DeleteProduct(p);
           
            return NoContent();
        }

    }
}
