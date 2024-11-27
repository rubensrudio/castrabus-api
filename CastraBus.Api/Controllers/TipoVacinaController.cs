using CastraBus.Application.Entities.ViewModel;
using CastraBus.Application.Services.Concret;
using CastraBus.Infra.Data.Entities.Concret;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CastraBus.Api.Controllers
{
    /// <summary>
    /// Classe Controller de Tipo Vacina
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TipoVacinaController : ControllerBase
    {
        private readonly Serilog.ILogger _logger;
        private readonly TipoVacinaServiceAsync<TipoVacinaVm, TipoVacinaEntity> tipoVacinaService;

        /// <summary>
        /// Construtor da controller Tipo Vacina
        /// </summary>
        /// <param name="tipoVacinaService">Injeção de dependência do serviço de Tipo Vacina</param>
        public TipoVacinaController(TipoVacinaServiceAsync<TipoVacinaVm, TipoVacinaEntity> tipoVacinaService, Serilog.ILogger logger)
        {
            this.tipoVacinaService = tipoVacinaService;
            this._logger = logger;
        }

        /// <summary>
        /// Método para obter todos os Tipo Vacina
        /// </summary>
        /// <returns>Retorna todos os Tipo Vacina</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            try
            {
                this._logger.Information("Obtendo todos os Tipo Vacina");
                var result = await this.tipoVacinaService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Get de Tipo Vacina, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para obter um determinando Tipo Vacina
        /// </summary>
        /// <param name="id">Id do Tipo Vacina</param>
        /// <returns>Retorna um objeto Tipo Vacina</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(Int64 id)
        {
            try
            {
                this._logger.Information($"obtendo um determinando Tipo Vacina {id}");
                var result = await this.tipoVacinaService.GetOne(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Get de Tipo Vacina, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para criar um Tipo Vacina
        /// </summary>
        /// <param name="tipoVacina">Objeto para inserir um Tipo Vacina</param>
        /// <returns>Retorna um objeto DataResult</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] TipoVacinaVm tipoVacina)
        {
            try
            {
                this._logger.Information("Criando um Tipo Vacina");
                return Ok(await this.tipoVacinaService.Insert(tipoVacina));
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Post de Tipo Vacina, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para atualizar um Tipo Vacina
        /// </summary>
        /// <param name="id">Id do Tipo Vacina a ser atualizado</param>
        /// <param name="tipoVacina">Objeto para atualizar um Tipo Vacina</param>
        /// <returns>Retorna um objeto DataResult</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(Int64 id, [FromBody] TipoVacinaVm tipoVacina)
        {
            try
            {
                this._logger.Information($"Atualizando um Tipo Vacina {id}");
                tipoVacina.Id = id;
                return Ok(await this.tipoVacinaService.Update(tipoVacina));
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Update de Tipo Vacina, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para Remover um Tipo Vacina
        /// </summary>
        /// <param name="id">Id do Tipo Vacina a ser removido</param>
        /// <returns>Retorna um objeto DataResult</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(Int64 id)
        {
            try
            {
                this._logger.Information($"Removendo um Tipo Vacina {id}");
                return Ok(await this.tipoVacinaService.Delete(id));
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Delete de Tipo Vacina, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }
    }
}
