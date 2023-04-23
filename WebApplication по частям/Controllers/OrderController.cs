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
using WebApplication2.Contracts.Order;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderService _orderService; 
        public OrderController(IOrderService cusromerService)
        {
            _orderService = cusromerService;
        }
        /// <summary>
        /// Просмотор заказов
        /// </summary>
        /// <param name="order">Заказ</param> 
        // POST api/<OrderController> 
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _orderService.GetAll());
        }
        /// <summary>
        /// Получение заказа по его коду
        /// </summary>
        /// <param name="order">Заказ</param> 
        // POST api/<OrderController>  
        [HttpGet(template: "{OrderCode}")]
        public async Task<IActionResult> GetById(int OrderCode)
        {
            var result = await _orderService.GetById(OrderCode); 
            var response = new GetOrderResponse() 
            {
                OrderCode = result.OrderCode,
                IdUser = result.IdUser,
                LtemNumber = result.LtemNumber,
                EmployeeCode = result.EmployeeCode,
                DateAndTime = result.DateAndTime,
                Status = result.Status,
                Quantity = result.Quantity,
                DeliveryMethod = result.DeliveryMethod, 
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
        ///        "idUser": 42,
        ///        "ltemNumber": 2,
        ///        "employeeCode": 22,
        ///        "dateAndTime": "2023-04-23T18:33:32.555Z",
        ///        "status": "poluchin",
        ///        "quantity": 3,
        ///        "deliveryMethod": "pickup"
        ///     }
        /// </remarks>
        /// <param name="order">Заказ</param> 
        /// <returns></returns>

        // POST api/<OrderController> 
        [HttpPost]
        public async Task<IActionResult> Add(CreateOrderRequest request)
        {
            var orderDto = request.Adapt<Order>();
            await _orderService.Create(orderDto); 
            return Ok();
        }
        /// <summary>
        /// Обновить заказ
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///     
        ///     POST /Todo
        ///     {
        ///        "orderCode": 98,
        ///        "idUser": 1,
        ///        "ltemNumber": 11,
        ///        "employeeCode": 4,
        ///        "dateAndTime": "2023-04-23T18:33:32.555Z",
        ///        "status": "poluchin",
        ///        "quantity": 1000,
        ///        "deliveryMethod": "mail"
        ///     }
        /// </remarks>
        /// <param name="order">Заказ</param> 
        /// <returns></returns>

        // POST api/<OrderController> 
        [HttpPut]
        public async Task<IActionResult> Update(UpdateOrder request) 
        {
            var orderDto = request.Adapt<Order>(); 
            await _orderService.Update(orderDto);
            return Ok();
        }
        /// <summary>
        /// Удалить заказ
        /// </summary>
        /// <param name="order">Заказ</param>
        // POST api/<OrderController>
        [HttpDelete]
        public async Task<IActionResult> Delete(int OrderCode)
        {
            await _orderService.Delete(OrderCode);
            return Ok();
        }
    }
}
