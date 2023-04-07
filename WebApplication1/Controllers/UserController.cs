using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Contracts.User;
using Mapster;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        /// <summary>
        /// Получение списка всех пользователей БД
        /// </summary>
        /// <param name="customer">Пользователь</param>
        // POST api/<UsersController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _userService.GetAll());
        }
        /// <summary>
        /// Получение пользователя по его id
        /// </summary>
        /// <param name="customer">Пользователь</param>
        // POST api/<UsersController>
        [HttpGet(template:"{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _userService.GetById(id);
            var response = new GetUserResponse()
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
        ///        "Birthdate" : "1982-09-25",
        ///     }
        /// </remarks>
        /// <param name="customer">Пользователь</param>
        /// <returns></returns>
        
        // POST api/<UsersController>
        [HttpPost]
        public async Task<IActionResult> Add(CreateUserRequest request)  
        {
            var userDto = request.Adapt<Customer>();
            await _userService.Create(userDto);
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
        ///        "Birthdate" : "1982-09-25",
        ///     }
        /// </remarks>
        /// <param name="customer">Пользователь</param>
        // POST api/<UsersController>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateUser cust)
        {
            var Dto = new Customer()
            {
                ClieNtCode = cust.ClieNtCode,
                Nickname = cust.Nickname,
                Password = cust.Password,
                Surname = cust.Surname,
                Name = cust.Name,
                MiddleName = cust.MiddleName,
                Mail = cust.Mail,
                PhoneNumber = cust.PhoneNumber,
                Birthdate = cust.Birthdate,
            };
            await _userService.Update(Dto);
            return Ok();
        }
        /// <summary>
        /// Удалить пользователя 
        /// </summary>
        /// <param name="customer">Пользователь</param>
        // POST api/<UsersController>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.Delete(id);
            return Ok();
        }
    }
}
