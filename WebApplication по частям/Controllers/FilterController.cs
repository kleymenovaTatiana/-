using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using DataAccess.Models;
using System.Xml.Linq;
using Mapster;
using BusinessLogic.Services;
using WebApplication2.Contracts.Filter;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilterController : ControllerBase
    {
        private IfilterService _filterService; 
        public FilterController(IfilterService cusromerService)  
        {
            _filterService = cusromerService;
        }
        /// <summary>
        /// Просмотор фильтра
        /// </summary>
        /// <param name="filter">Фильтер</param> 
        // POST api/<FilterController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _filterService.GetAll()); 
        }
        /// <summary>
        /// Получение пользователя по его id
        /// </summary>
        /// <param name="filter">Фильтер</param>
        // POST api/<FilterController> 
        [HttpGet(template: "{CategoryId}")]
        public async Task<IActionResult> GetById(int CategoryId)
        {
            var result = await _filterService.GetById(CategoryId);
            var response = new GetFilterResponse() 
            {
                CategoryId = result.CategoryId,
                Feed = result.Feed,
                Toys = result.Toys,
                Bowls = result.Bowls,
                Aquariums = result.Aquariums,
            };
            return Ok(response);
        }
        /// <summary>
        /// Создание нового товара в фильтре
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///     
        ///     POST /Todo
        ///     {
        ///        "feed": "Yami",
        ///        "toys": "Tetra",
        ///        "bowls": "No",
        ///        "aquariums": "Moderna"
        ///     }
        /// </remarks>
        /// <param name="filter">Фильтер</param>
        /// <returns></returns>

        // POST api/<FilterController>
        [HttpPost]
        public async Task<IActionResult> Add(CreateFilterRequest request) 
        {
            var filterDto = request.Adapt<Filter>();
            await _filterService.Create(filterDto);
            return Ok();
        }
        /// <summary>
        /// Обновить товара в фильтре
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///     
        ///     POST /Todo
        ///     {
        ///        "categoryId": 111,
        ///        "feed": "Purina",
        ///        "toys": "Tappi",
        ///        "bowls": "Yami",
        ///        "aquariums": "No"
        ///     }
        /// </remarks>
        /// <param name="filter">Фильтер</param>
        /// <returns></returns>

        // POST api/<FilterController>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateFilter request)
        {
            var filterDto = request.Adapt<Filter>(); 
            await _filterService.Update(filterDto); 
            return Ok();
        }
        /// <summary>
        /// Удалить товар в фильтре
        /// </summary>
        /// <param name="filter">Фильтер</param>
        // POST api/<FilterController>
        [HttpDelete]
        public async Task<IActionResult> Delete(int CategoryId)
        {
            await _filterService.Delete(CategoryId);
            return Ok();
        }
    }
}
