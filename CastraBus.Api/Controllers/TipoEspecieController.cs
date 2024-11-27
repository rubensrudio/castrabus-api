using CastraBus.Application.Entities.ViewModel;
using CastraBus.Application.Services.Concret;
using CastraBus.Infra.Data.Entities.Concret;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CastraBus.Api.Controllers
{
    /// <summary>
    /// Classe Controller de Tipo Especie
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TipoEspecieController : ControllerBase
    {
        private readonly Serilog.ILogger _logger;
        private readonly TipoEspecieServiceAsync<TipoEspecieVm, TipoEspecieEntity> tipoEspecieService;

        /// <summary>
        /// Construtor da controller Tipo Especie
        /// </summary>
        /// <param name="tipoEspecieService">Injeção de dependência do serviço de Tipo Especie</param>
        /// <param name="logger">Injeção de dependência do serviço de Serilog.ILogger</param>
        public TipoEspecieController(TipoEspecieServiceAsync<TipoEspecieVm, TipoEspecieEntity> tipoEspecieService, Serilog.ILogger logger)
        {
            this.tipoEspecieService = tipoEspecieService;
            _logger = logger;
        }

        /// <summary>
        /// Método para obter todos os Tipo Especie
        /// </summary>
        /// <returns>Retorna todos os Tipo Especie</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            try
            {
                this._logger.Information("Obtendo todos os Tipo Especie");
                var result = await this.tipoEspecieService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Get de Tipo Especie, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para obter um determinando Tipo Especie
        /// </summary>
        /// <param name="id">Id do Tipo Especie</param>
        /// <returns>Retorna um objeto Tipo Especie</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(Int64 id)
        {
            try
            {
                this._logger.Information($"Obtendo um determinando Tipo Especie {id}");
                var result = await this.tipoEspecieService.GetOne(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Get de Tipo Especie, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para criar um Tipo Especie
        /// </summary>
        /// <param name="tipoEspecie">Objeto para inserir um Tipo Especie</param>
        /// <returns>Retorna um objeto DataResult</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] TipoEspecieVm tipoEspecie)
        {
            try
            {
                return Ok(await this.tipoEspecieService.Insert(tipoEspecie));
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Insert de Tipo Especie, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para atualizar um Tipo Especie
        /// </summary>
        /// <param name="id">Id do Tipo Especie a ser atualizado</param>
        /// <param name="tipoEspecie">Objeto para atualizar um Tipo Especie</param>
        /// <returns>Retorna um objeto DataResult</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(Int64 id, [FromBody] TipoEspecieVm tipoEspecie)
        {
            try
            {
                tipoEspecie.Id = id;
                return Ok(await this.tipoEspecieService.Update(tipoEspecie));
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Update de Tipo Especie, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para Remover um Tipo Especie
        /// </summary>
        /// <param name="id">Id do Tipo Especie a ser removido</param>
        /// <returns>Retorna um objeto DataResult</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(Int64 id)
        {
            try
            {
                return Ok(await this.tipoEspecieService.Delete(id));
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Delete de Tipo Especie, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }
    }
}
