using GameServer.Domain.Entity.Dto;
using GameServer.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GameServer.Controllers
{
    [Route("api/")]
    [Produces("application/json")]
    public class ServerController : ControllerBase
    {
        private readonly IServerService _serverSer;
        public ServerController(IServerService serverSer) => _serverSer = serverSer;

        /// <summary>
        /// Список всех серверов.
        /// </summary>
        /// <returns>Вывод всех серверов.</returns>
        /// <remarks>
        /// Образец запроса:
        /// 
        ///     GET /servers
        ///
        /// </remarks> 
        /// <response code="200"> Запрос прошёл. (Успех) </response>
        /// <response code="404"> Список серверов не найден. </response>
        [HttpGet]
        [Route("servers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get()
        {
            var servers = await _serverSer.GetServiceAsync();
            if (servers.Result.Count() == 0)
            {
                return NotFound(servers);
            }
            return Ok(servers);
        }
        /// <summary>
        /// Вывод сервера по id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Вывод данных сервера</returns>
        /// <remarks>
        /// Образец запроса:
        /// 
        ///     GET /server/{id}
        ///     
        ///        ServerId: guid   // Введите id сервера, который нужно показать.
        ///     
        /// </remarks>
        /// <response code="200"> Запрос прошёл. (Успех) </response>
        /// <response code="404"> Сервер не найден. </response>
        [HttpGet]
        [Route("server/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var server = await _serverSer.GetByIdAsync(id);
            if (server.Result is null)
            {
                return NotFound(server);
            }
            return Ok(server);
        }
        /// <summary>
        /// Вывод сервера по уникальному адресу.
        /// </summary>
        /// <param name="uniqueAddress"></param>
        /// <returns>Вывод данных сервера</returns>
        /// <remarks>
        /// Образец запроса:
        /// 
        ///     GET /server/{uniqueaddress}
        ///     
        ///        UniqueAddress: "string"   // Введите уникальный адрес сервера, который нужно показать.
        ///     
        /// </remarks>
        /// <response code="200"> Запрос прошёл. (Успех) </response>
        /// <response code="404"> Сервер не найден. </response>
        [HttpGet]
        [Route("server/{uniqueaddress}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(string uniqueAddress)
        {
            var server = await _serverSer.GetByIdAsync(uniqueAddress);
            if (server.Result is null)
            {
                return NotFound(server);
            }
            return Ok(server);
        }
        /// <summary>
        /// Создание нового сервера.
        /// </summary>
        /// <param name="serverDto"></param>
        /// <returns>Создаётся сервер</returns>
        /// <remarks>
        /// 
        ///     Свойство ["UniqAddress"] введите без пробелов и дефисов (состоит цифр и символов '.' и ':')
        /// 
        /// Образец ввовда данных:
        ///
        ///     POST /server
        ///     
        ///     {
        ///       "ServerId": guid,             // id сервера.
        ///       "UniqAddress": "string",      // Уникальный адрес.                            
        ///       "HashGameSession" "string",   // Хеш игровой сессии.
        ///       "MaxPlayers": 0,              // Максимальное количество игроков.
        ///       "CurrentPlayers": 0           // Действующие игроки.
        ///       "Region": "string",           // Регион. 
        ///       "Develop": bool,              // Развивать.
        ///       "Name": "string"              // Название сервера.
        ///       "GameMode":"string",          // Режим игры.
        ///       "MapName": "string",          // Название карты.                            
        ///       "Lifetime": 0,                // Время жизни сервера.
        ///       "Status": "string"            // Статус сервера.
        ///       "VerifyKey": "string",        // Верифицирующий ключ. 
        ///     }
        ///
        /// </remarks>
        /// <response code="201"> Сервер создан. </response>
        /// <response code="400"> Введены недопустимые данные. </response>
        [HttpPost]
        [Route("server")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] ServerDto serverDto)
        {
            if (ModelState.IsValid)
            {
                var book = await _serverSer.CreateServiceAsync(serverDto);
                return CreatedAtAction(nameof(Get), book);
            }
            return BadRequest("Введены недопустимые данные");
        }
        /// <summary>
        /// Обновление сервера.
        /// </summary>
        /// <param name="serverDto"></param>
        /// <returns>Сервер обновился.</returns>
        /// <remarks>
        /// 
        ///     Свойство ["UniqAddress"] введите без пробелов и дефисов (состоит цифр и символов '.' и ':')
        /// 
        /// Образец ввовда данных:
        ///
        ///     PUT /server
        ///     
        ///     {
        ///       "ServerId": guid,             // id сервера.
        ///       "UniqAddress": "string",      // Уникальный адрес.                            
        ///       "HashGameSession" "string",   // Хеш игровой сессии.
        ///       "MaxPlayers": 0,              // Максимальное количество игроков.
        ///       "CurrentPlayers": 0           // Действующие игроки.
        ///       "Region": "string",           // Регион. 
        ///       "Develop": bool,              // Развивать.
        ///       "Name": "string"              // Название сервера.
        ///       "GameMode":"string",          // Режим игры.
        ///       "MapName": "string",          // Название карты.                            
        ///       "Lifetime": 0,                // Время жизни сервера.
        ///       "Status": "string"            // Статус сервера.
        ///       "VerifyKey": "string",        // Верифицирующий ключ. 
        ///     }
        ///
        /// </remarks>
        /// <response code="200"> Запрос прошёл. (Успех) </response>
        /// <response code="400"> Введены недопустимые данные. </response>
        /// <response code="404"> Сервер не найден. </response>
        /// <response code="500"> Внутренняя ошибка сервера. </response>
        [HttpPut]
        [Route("server")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update([FromBody] ServerDto serverDto)
        {
            if (ModelState.IsValid)
            {
                var book = await _serverSer.UpdateServiceAsync(serverDto);
                if (book.Result is null)
                {
                    return NotFound(book);
                }
                return Ok(book);
            }
            return BadRequest("Введены недопустимые данные");
        }
        /// <summary>
        /// Удаление сервера по id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Сервер удаляется.</returns>
        /// <remarks>
        /// Образец запроса:
        /// 
        ///     DELETE /server/{id}
        ///     
        ///        ServerId: guid   // Введите id сервера, который нужно удалить.
        ///     
        /// </remarks>
        /// <response code="204"> Сервер удалён. (нет содержимого) </response>
        /// <response code="404"> Сервер c указанным id не найден. </response>
        [HttpDelete]
        [Route("server/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var user = await _serverSer.DeleteServiceAsync(id);
            if (user.Result is false)
            {
                return NotFound(user);
            }
            return NoContent();
        }
        /// <summary>
        /// Удаление сервера по уникальныму адресу.
        /// </summary>
        /// <param name="address"></param>
        /// <returns>Сервер удаляется.</returns>
        /// <remarks>
        /// Образец запроса:
        /// 
        ///     DELETE /server/{address}
        ///     
        ///        UniqueAddress: "string"   // Введите уникальный адрес сервера, который нужно удалить.
        ///     
        /// </remarks>
        /// <response code="204"> Сервер удалён. (нет содержимого) </response>
        /// <response code="404"> Сервер не найден. </response>
        [HttpDelete]
        [Route("server")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(string address)
        {
            var user = await _serverSer.DeleteServiceAsync(address);
            if (user.Result is false)
            {
                return NotFound(user);
            }
            return NoContent();
        }
    }
}