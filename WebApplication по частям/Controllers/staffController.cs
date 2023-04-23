using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;
using Domain.Models;
using BusinessLogic.Services;
using Mapster;
using WebApplication2.Contracts.Products1;
using WebApplication2.Contracts.staff;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class staffController : ControllerBase
    {
        private IStaffrService _staffrService;
        public staffController(IStaffrService cusromerService)
        {
            _staffrService = cusromerService;
        }
        /// <summary>
        /// Получение списка всего персонала БД
        /// </summary>
        /// <param name="staff">Персонал</param>
        // POST api/<StaffController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _staffrService.GetAll());
        }
        /// <summary>
        /// Получение персонала по его id
        /// </summary>
        /// <param name="staff">Персонал</param>
        // POST api/<StaffController>
        [HttpGet(template: "{EmployeeCode}")]
        public async Task<IActionResult> GetById(int EmployeeCode)
        {
            var result = await _staffrService.GetById(EmployeeCode);
            var response = new GetstaffResponse() 
            {
                EmployeeCode = result.EmployeeCode,
                Nickname = result.Nickname,
                Password = result.Password,
                Surname = result.Surname,
                Namee = result.Namee,
                MiddleName = result.MiddleName,
                Mail = result.Mail,
                PhoneNumber = result.PhoneNumber,
                Birthdate = result.Birthdate,
            };
            return Ok(response);
        }
        /// <summary>
        /// Создание нового персонала
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///     
        ///     POST /Todo
        ///     {
        ///        "nickname": "mo",
        ///        "password": "11631",
        ///        "surname": "Vavilova",
        ///        "namee": "Sofya",
        ///        "middleName": "Vladimirovna",
        ///        "mail": "ala@mail.ru",
        ///        "phoneNumber": "74725939",
        ///        "birthdate": "2023-04-23T19:02:00.758Z"
        ///     }
        /// </remarks>
        /// <param name="staff">Персонал</param>
        /// <returns></returns>

        // POST api/<StaffController>
        [HttpPost]
        public async Task<IActionResult> Add(CreatestaffRequest request)
        {
            var staffDto = request.Adapt<staff>();
            await _staffrService.Create(staffDto); 
            return Ok();
        }
        /// <summary>
        /// Обновиление персонала
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///     
        ///     POST /Todo
        ///     {
        ///        "employeeCode": 4,
        ///        "nickname": "li",
        ///        "password": "11631",
        ///        "surname": "Pavlova",
        ///        "namee": "Arina",
        ///        "middleName": "Mironovna",
        ///        "mail": "mana@mail.ru",
        ///        "phoneNumber": "72563929",
        ///        "birthdate": "2023-04-23T19:02:00.758Z"
        ///     }
        /// </remarks>
        /// <param name="staff">Персонал</param>
        /// <returns></returns>

        // POST api/<Products1Controller> 
        [HttpPut]
        public async Task<IActionResult> Update(Updatestaff request)
        {
            var staffDto = request.Adapt<staff>();
            await _staffrService.Update(staffDto);
            return Ok();
        }
        /// <summary>
        /// Удалить персонал
        /// </summary>
        /// <param name="staff">Персонал</param>
        // POST api/<Products1Controller> 
        [HttpDelete]
        public async Task<IActionResult> Delete(int EmployeeCode)
        {
            await _staffrService.Delete(EmployeeCode); 
            return Ok();
        }
    }
}
