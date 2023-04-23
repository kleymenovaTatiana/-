using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Contracts.Customer;
using DataAccess.Models;
using System.Xml.Linq;
using Mapster;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerService _customerService;  
        public CustomerController(ICustomerService cusromerService)
        {
            _customerService = cusromerService;
        }
        /// <summary>
        /// Получение списка всех пользователей БД
        /// </summary>
        /// <param name="customer">Пользователь</param>
        // POST api/<CustomerController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _customerService.GetAll());
        }
        /// <summary>
        /// Получение пользователя по его id
        /// </summary>
        /// <param name="customer">Пользователь</param>
        // POST api/<CustomerController>
        [HttpGet(template:"{ClieNtCode}")]
        public async Task<IActionResult> GetById(int ClieNtCode)
        {
            var result = await _customerService.GetById(ClieNtCode);
            var response = new GetCustomerResponse()  
            {
                ClieNtCode = result.ClieNtCode,
                Nickname = result.Nickname,
                Password = result.Password,
                Surname = result.Surname,
                Name = result.Name,
                MiddleName = result.MiddleName,
                Mail = result.Mail,
                PhoneNumber = result.PhoneNumber,
                Birthdate = result.Birthdate,
            };
            return Ok(response);
        }
        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///     
        ///     POST /Todo
        ///     {
        ///        "Nickname" : "Sea",
        ///        "Password" : "98745",
        ///        "Surname" : "Polyakova",
        ///        "Name" : "Sofia",
        ///        "Middle_name" : "Grigorievna",
        ///        "Mail" : "house@mail.ru",
        ///        "Phone_number" : "79830040",
        ///        "Birthdate" : "2023-04-23T15:01:57.672Z",
        ///     }
        /// </remarks>
        /// <param name="customer">Пользователь</param>
        /// <returns></returns>

        // POST api/<CustomerController>
        [HttpPost]
        public async Task<IActionResult> Add(CreateCustomerRequest request)  
        {
            var customerDto = request.Adapt<Customer>(); 
            await _customerService.Create(customerDto);
            return Ok();
        }
        /// <summary>
        /// Обновить пользователя
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///     
        ///     POST /Todo
        ///     {
        ///        "ClieNtCode" : "0",
        ///        "Nickname" : "Sea",
        ///        "Password" : "745",
        ///        "Surname" : "Sofia",
        ///        "Name" : "Polyakova",
        ///        "Middle_name" : "Grigorievna",
        ///        "Mail" : "house@mail.ru",
        ///        "Phone_number" : "79830040",
        ///        "Birthdate" : "2023-04-23T15:01:57.672Z",
        ///     }
        /// </remarks>
        /// <param name="customer">Пользователь</param>
        // POST api/<CustomerController>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateCustomer request) 
        {
            var customerDto = request.Adapt<Customer>();
            await _customerService.Update(customerDto);
            return Ok();
        }
        /// <summary>
        /// Удалить пользователя 
        /// </summary>
        /// <param name="customer">Пользователь</param>
        // POST api/<CustomerController> 
        [HttpDelete]
        public async Task<IActionResult> Delete(int ClieNtCode)
        {
            await _customerService.Delete(ClieNtCode);
            return Ok();
        }
    }
}
