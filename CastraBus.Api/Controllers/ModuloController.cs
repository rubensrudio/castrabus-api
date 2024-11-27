using CastraBus.Application.Entities.ViewModel;
using CastraBus.Application.Services.Concret;
using CastraBus.Infra.Data.Entities.Concret;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CastraBus.Api.Controllers
{
    /// <summary>
    /// Classe Controller de Modulo
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ModuloController : ControllerBase
    {
        private readonly Serilog.ILogger _logger;
        private readonly ModuloServiceAsync<ModuloVm, ModuloEntity> _moduloService;

        /// <summary>
        /// Construtor da controller Modulo
        /// </summary>
        /// <param name="moduloService">Injeção de dependência do serviço de Modulo</param>
        /// <param name="logger">Injeção de dependência do serviço de Serilog.ILogger</param>
        public ModuloController(ModuloServiceAsync<ModuloVm, ModuloEntity> moduloService, Serilog.ILogger logger)
        {
            this._moduloService = moduloService;
            this._logger = logger;
        }

        /// <summary>
        /// Método para Obter todos os Modulo
        /// </summary>
        /// <returns>Retorna todos os Modulo</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            try
            {
                this._logger.Information("Obtendo todos os Modulo");
                var result = await this._moduloService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Get de Modulo, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para Obter um determinando Modulo
        /// </summary>
        /// <param name="id">Id do Modulo</param>
        /// <returns>Retorna um objeto Modulo</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(Int64 id)
        {
            try
            {
                this._logger.Information($"Obtendo um determinando Modulo {id}");
                var result = await this._moduloService.GetOne(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Get de Modulo, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para criar um Modulo
        /// </summary>
        /// <param name="modulo">Objeto para inserir um Modulo</param>
        /// <returns>Retorna um objeto DataResult</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] ModuloVm modulo)
        {
            try
            {
                return Ok(await this._moduloService.Insert(modulo));
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Criar um Modulo, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para atualizar um Modulo
        /// </summary>
        /// <param name="id">Id do Modulo a ser atualizado</param>
        /// <param name="modulo">Objeto para atualizar um Modulo</param>
        /// <returns>Retorna um objeto DataResult</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(Int64 id, [FromBody] ModuloVm modulo)
        {
            try
            {
                modulo.Id = id;
                return Ok(await this._moduloService.Update(modulo));
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Update de Modulo, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para Remover um Modulo
        /// </summary>
        /// <param name="id">Id do Modulo a ser removido</param>
        /// <returns>Retorna um objeto DataResult</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(Int64 id)
        {
            try
            {
                return Ok(await this._moduloService.Delete(id));
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Delete de Modulo, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }
    }
}
