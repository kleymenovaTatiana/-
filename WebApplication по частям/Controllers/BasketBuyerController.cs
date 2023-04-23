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

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketBuyerController : ControllerBase 
    {
        private IBasket_BuyerService _basket_BuyerService;
        public BasketBuyerController(IBasket_BuyerService basket_BuyerService) 
        {
            _basket_BuyerService = basket_BuyerService;
        }
        /// <summary>
        /// Получение количества
        /// </summary>
        /// <param name="basketBuyer">Корзина покупателя</param>
        // POST api/<BasketBuyerController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _basket_BuyerService.GetAll());
        }
        /// <summary>
        /// Получение количества по его id
        /// </summary>
        /// <param name="basketBuyer">Корзина покупателя</param>
        // POST api/<BasketBuyerController>
        [HttpGet(template: "{IdUser}")]
        public async Task<IActionResult> GetById(int IdUser)
        {
            var result = await _basket_BuyerService.GetById(IdUser);
            var response = new GetBasketBuyerResponse()
            {
                IdUser = result.IdUser,
                LtemNumber = result.LtemNumber,
                Quantity = result.Quantity,
            };
            return Ok(response);
        }
        /// <summary>
        /// Создание нового заказа
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///     
        ///     POST /Todo
        ///     {
        ///        "ltemNumber": 11,
        ///        "quantity": 40,
        ///     }
        /// </remarks>
        /// <param name="basket_Buyer">Корзина покупателя</param>
        /// <returns></returns>

        // POST api/<BasketBuyerController>
        [HttpPost]
        public async Task<IActionResult> Add(CreateBasketBuyerRequest request) 
        {
            var basket_BuyerDto = request.Adapt<BasketBuyer>();
            await _basket_BuyerService.Create(basket_BuyerDto); 
            return Ok();
        }
        /// <summary>
        /// Обновить заказа
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///     
        ///     POST /Todo
        ///     {
        ///        "idUser": 1,
        ///        "ltemNumber": 11,
        ///        "quantity": 50,
        ///     }
        /// </remarks>
        /// <param name="basket_Buyer">Корзина покупателя</param>
        /// <returns></returns>

        // POST api/<BasketBuyerController>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateBasketBuyer request)
        {
            var basket_BuyerDto = request.Adapt<BasketBuyer>();
            await _basket_BuyerService.Update(basket_BuyerDto);
            return Ok();
        }
        /// <summary>
        /// Удалить заказ из корзины 
        /// </summary>
        /// <param name="basket_Buyer">Корзина покупателя</param>
        // POST api/<BasketBuyerController> 
        [HttpDelete]
        public async Task<IActionResult> Delete(int IdUser)
        {
            await _basket_BuyerService.Delete(IdUser);
            return Ok();
        }
    }
}
