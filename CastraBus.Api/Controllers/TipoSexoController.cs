using CastraBus.Application.Entities.ViewModel;
using CastraBus.Application.Services.Concret;
using CastraBus.Infra.Data.Entities.Concret;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CastraBus.Api.Controllers
{
    /// <summary>
    /// Classe Controller de Tipo Sexo
    /// </summary>
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TipoSexoController : ControllerBase
    {
        private readonly Serilog.ILogger _logger;
        private readonly TipoSexoServiceAsync<TipoSexoVm, TipoSexoEntity> tipoSexoService;

        /// <summary>
        /// Construtor da controller Tipo Sexo
        /// </summary>
        /// <param name="tipoSexoService">Injeção de dependência do serviço de Tipo Sexo</param>
        /// <param name="logger">Injeção de dependência do serviço de Serilog.ILogger</param>
        public TipoSexoController(TipoSexoServiceAsync<TipoSexoVm, TipoSexoEntity> tipoSexoService, Serilog.ILogger logger)
        {
            this.tipoSexoService = tipoSexoService;
            this._logger = logger;
        }

        /// <summary>
        /// Método para obter todos os Tipo Sexo
        /// </summary>
        /// <returns>Retorna todos os Tipo Sexo</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            try
            {
                this._logger.Information("Obtendo todos os Tipo Sexo");
                var result = await this.tipoSexoService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Get de Tipo Sexo, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para obter um determinando Tipo Sexo
        /// </summary>
        /// <param name="id">Id do Tipo Sexo</param>
        /// <returns>Retorna um objeto Tipo Sexo</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(Int64 id)
        {
            try
            {
                this._logger.Information($"Obtendo um determinando Tipo Sexo {id}");
                var result = await this.tipoSexoService.GetOne(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Get de Tipo Sexo, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para criar um Tipo Sexo
        /// </summary>
        /// <param name="tipoSexo">Objeto para inserir um Tipo Sexo</param>
        /// <returns>Retorna um objeto DataResult</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] TipoSexoVm tipoSexo)
        {
            try
            {
                return Ok(await this.tipoSexoService.Insert(tipoSexo));
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Insert de Tipo Sexo, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para atualizar um Tipo Sexo
        /// </summary>
        /// <param name="id">Id do Tipo Sexo a ser atualizado</param>
        /// <param name="tipoSexo">Objeto para atualizar um Tipo Sexo</param>
        /// <returns>Retorna um objeto DataResult</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(Int64 id, [FromBody] TipoSexoVm tipoSexo)
        {
            try
            {
                tipoSexo.Id = id;
                return Ok(await this.tipoSexoService.Update(tipoSexo));
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Update de Tipo Sexo, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para Remover um Tipo Sexo
        /// </summary>
        /// <param name="id">Id do Tipo Sexo a ser removido</param>
        /// <returns>Retorna um objeto DataResult</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(Int64 id)
        {
            try
            {
                return Ok(await this.tipoSexoService.Delete(id));
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Delete de Tipo Sexo, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }
    }
}
