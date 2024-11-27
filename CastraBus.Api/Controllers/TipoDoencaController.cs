using CastraBus.Application.Entities.ViewModel;
using CastraBus.Application.Services.Concret;
using CastraBus.Infra.Data.Entities.Concret;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CastraBus.Api.Controllers
{
    /// <summary>
    /// Classe Controller de Tipo Doença
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDoencaController : ControllerBase
    {
        private readonly Serilog.ILogger _logger;
        private readonly TipoDoencaServiceAsync<TipoDoencaVm, TipoDoencaEntity> tipoDoencaService;

        /// <summary>
        /// Construtor da controller Tipo Doença
        /// </summary>
        /// <param name="tipoDoencaService">Injeção de dependência do serviço de Tipo Doença</param>
        public TipoDoencaController(TipoDoencaServiceAsync<TipoDoencaVm, TipoDoencaEntity> tipoDoencaService, Serilog.ILogger logger)
        {
            this.tipoDoencaService = tipoDoencaService;
            _logger = logger;
        }

        /// <summary>
        /// Método para obter todos os Tipo Doença
        /// </summary>
        /// <returns>Retorna todos os Tipo Doença</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            try
            {
                this._logger.Information("Obtendo todos os Tipo Doença");
                var result = await this.tipoDoencaService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Get de Tipo Doença, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para obter um determinando Tipo Doença
        /// </summary>
        /// <param name="id">Id do Tipo Doença</param>
        /// <returns>Retorna um objeto Tipo Doença</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(Int64 id)
        {
            try
            {
                this._logger.Information($"Obtendo um determinando Tipo Doença {id}");
                var result = await this.tipoDoencaService.GetOne(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Get de Tipo Doença, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para criar um Tipo Doença
        /// </summary>
        /// <param name="tipoDoenca">Objeto para inserir um Tipo Doença</param>
        /// <returns>Retorna um objeto DataResult</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] TipoDoencaVm tipoDoenca)
        {
            try
            {
                return Ok(await this.tipoDoencaService.Insert(tipoDoenca));
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Insert de Tipo Doença, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para atualizar um Tipo Doença
        /// </summary>
        /// <param name="id">Id do Tipo Doença a ser atualizado</param>
        /// <param name="tipoDoenca">Objeto para atualizar um Tipo Doença</param>
        /// <returns>Retorna um objeto DataResult</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(Int64 id, [FromBody] TipoDoencaVm tipoDoenca)
        {
            try
            {
                tipoDoenca.Id = id;
                return Ok(await this.tipoDoencaService.Update(tipoDoenca));
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Update de Tipo Doença, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para Remover um Tipo Doença
        /// </summary>
        /// <param name="id">Id do Tipo Doença a ser removido</param>
        /// <returns>Retorna um objeto DataResult</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(Int64 id)
        {
            try
            {
                return Ok(await this.tipoDoencaService.Delete(id));
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Delete de Tipo Doença, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }
    }
}
