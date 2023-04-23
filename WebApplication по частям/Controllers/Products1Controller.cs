using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;
using Domain.Models;
using BusinessLogic.Services;
using WebApplication2.Contracts.Order;
using WebApplication2.Contracts.Products1;
using Mapster;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Products1Controller : ControllerBase
    {
        private IProducts1Service _products1Service; 
        public Products1Controller(IProducts1Service cusromerService)
        {
            _products1Service = cusromerService;
        }
        /// <summary>
        /// Просмотор товаров
        /// </summary>
        /// <param name="products1">Товары</param> 
        // POST api/<Products1Controller>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _products1Service.GetAll());
        }
        /// <summary>
        /// Получение товара по его номеру
        /// </summary>
        /// <param name="products1">Товары</param> 
        // POST api/<Products1Controller>  
        [HttpGet("{LtemNumber}")]
        public async Task<IActionResult> GetById(int LtemNumber)
        {
            var result = await _products1Service.GetById(LtemNumber);
            var response = new GetProducts1Response()
            {
                LtemNumber = result.LtemNumber,
                CategoryId = result.CategoryId,
                Title = result.Title,
                Cost = result.Cost,
                Description = result.Description,
                ArticleNumber = result.ArticleNumber,
                NumberInClade = result.NumberInClade,
            };
            return Ok(response);
        }
        /// <summary>
        /// Создание нового товара
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///     
        ///     POST /Todo
        ///     {
        ///        "categoryId": 222,
        ///        "title": "dry",
        ///        "cost": 65,
        ///        "description": "cat food",
        ///        "articleNumber": 2460123,
        ///        "numberInClade": 24
        ///     }
        /// </remarks>
        /// <param name="products1">Товары</param> 
        /// <returns></returns>

        // POST api/<Products1Controller> 
        [HttpPost]
        public async Task<IActionResult> Add(CreateProducts1Request request) 
        {
            var products1Dto = request.Adapt<Products1>();
            await _products1Service.Create(products1Dto);
            return Ok();
        }
        /// <summary>
        /// Обновление товара
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///     
        ///     POST /Todo
        ///     {
        ///        "ltemNumber": 11,
        ///        "categoryId": 111,
        ///        "title": "feed",
        ///        "cost": 56,
        ///        "description": "cat food",
        ///        "articleNumber": 1951699,
        ///        "numberInClade": 22
        ///     }
        /// </remarks>
        /// <param name="products1">Товары</param> 
        /// <returns></returns>

        // POST api/<Products1Controller> 
        [HttpPut]
        public async Task<IActionResult> Update(UpdateProducts1 request)
        {
            var products1Dto = request.Adapt<Products1>();
            await _products1Service.Update(products1Dto);
            return Ok();
        }
        /// <summary>
        /// Удалить товар
        /// </summary>
        /// <param name="products1">Товары</param> 
        // POST api/<Products1Controller> 
        [HttpDelete]
        public async Task<IActionResult> Delete(int LtemNumber)
        {
            await _products1Service.Delete(LtemNumber);
            return Ok();
        }
    }
}
