using CastraBus.Application.Entities.ViewModel;
using CastraBus.Application.Services.Concret;
using CastraBus.Infra.Data.Entities.Concret;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CastraBus.Api.Controllers
{
    /// <summary>
    /// Classe Controller de Vacina
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class VacinaController : ControllerBase
    {
        private readonly Serilog.ILogger _logger;
        private readonly VacinaServiceAsync<VacinaVm, VacinaEntity> vacinaService;

        /// <summary>
        /// Construtor da controller Vacina
        /// </summary>
        /// <param name="vacinaService">Injeção de dependência do serviço de Vacina</param>
        /// <param name="logger">Injeção de dependência do serviço de Serilog.ILogger</param>
        public VacinaController(VacinaServiceAsync<VacinaVm, VacinaEntity> vacinaService, Serilog.ILogger logger)
        {
            this.vacinaService = vacinaService;
            _logger = logger;
        }

        /// <summary>
        /// Método para obter todos os Vacina
        /// </summary>
        /// <returns>Retorna todos os Vacina</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            try
            {
                this._logger.Information("Obtendo todos os Vacina");
                var result = await this.vacinaService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Get de Vacina, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para obter um determinando Vacina
        /// </summary>
        /// <param name="id">Id do Vacina</param>
        /// <returns>Retorna um objeto Vacina</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(Int64 id)
        {
            try
            {
                this._logger.Information($"Obtendo um determinando Vacina {id}");
                var result = await this.vacinaService.GetOne(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Get de Vacina, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para criar uma Vacina
        /// </summary>
        /// <param name="vacina">Objeto para inserir uma Vacina</param>
        /// <returns>Retorna um objeto DataResult</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] VacinaVm vacina)
        {
            try
            {
                return Ok(await this.vacinaService.Insert(vacina));
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Insert de Vacina, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para atualizar uma Vacina
        /// </summary>
        /// <param name="id">Id do Vacina a ser atualizado</param>
        /// <param name="vacina">Objeto para atualizar uma Vacina</param>
        /// <returns>Retorna um objeto DataResult</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(Int64 id, [FromBody] VacinaVm vacina)
        {
            try
            {
                vacina.Id = id;
                return Ok(await this.vacinaService.Update(vacina));
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Update de Vacina, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para Remover um Vacina
        /// </summary>
        /// <param name="id">Id do Vacina a ser removido</param>
        /// <returns>Retorna um objeto DataResult</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(Int64 id)
        {
            try
            {
                return Ok(await this.vacinaService.Delete(id));
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Delete de Vacina, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }
    }
}
