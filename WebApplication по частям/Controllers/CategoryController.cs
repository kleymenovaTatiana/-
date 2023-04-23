using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using DataAccess.Models;
using System.Xml.Linq;
using Mapster;
using BusinessLogic.Services;
using WebApplication2.Contracts.BasketBuyer;
using WebApplication2.Contracts.Category;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService) 
        {
            _categoryService = categoryService;
        }
        /// <summary>
        /// Получение категории товара
        /// </summary>
        /// <param name="сategory">Категория</param>
        // POST api/<сategoryController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _categoryService.GetAll());
        }
        /// <summary>
        /// Получение категории по его id
        /// </summary>
        /// <param name="сategory">Категория</param>
        // POST api/<сategoryController>
        [HttpGet(template: "{CategoryId}")]
        public async Task<IActionResult> GetById(int CategoryId)
        {
            var result = await _categoryService.GetById(CategoryId);
            var response = new GetCategoryResponse()
            {
                CategoryId = result.CategoryId,
                CategoryName = result.CategoryName,
            };
            return Ok(response);
        }
        /// <summary>
        /// Создание новой категории 
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///     
        ///     POST /Todo
        ///     {
        ///        "categoryName": "For_hamsters",
        ///     }
        /// </remarks>
        /// <param name="сategory">Категория</param>
        /// <returns></returns>

        // POST api/<сategoryController> 
        [HttpPost]
        public async Task<IActionResult> Add(CreateCategoryRequest request)
        {
            var categoryDto = request.Adapt<Category>();   
            await _categoryService.Create(categoryDto); 
            return Ok();
        }
        /// <summary>
        /// Обновить категорию  
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///     
        ///     POST /Todo
        ///     {
        ///        "categoryId": 0,
        ///        "categoryName": "For_turtles",
        ///     }
        /// </remarks>
        /// <param name="сategory">Категория</param>
        /// <returns></returns>

        // POST api/<сategoryController> 
        [HttpPut]
        public async Task<IActionResult> Update(UpdateCategory request)
        {
            var categoryDto = request.Adapt<Category>(); 
            await _categoryService.Update(categoryDto); 
            return Ok();
        }
        /// <summary>
        /// Удалить категорию
        /// </summary>
        /// <param name="сategory">Категория</param>
        // POST api/<сategoryController> 
        [HttpDelete]
        public async Task<IActionResult> Delete(int CategoryId)
        {
            await _categoryService.Delete(CategoryId);
            return Ok();
        }
    }
}
