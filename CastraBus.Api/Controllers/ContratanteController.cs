
using CastraBus.Application.Entities.ViewModel;
using CastraBus.Application.Services.Concret;
using CastraBus.Infra.Data.Entities.Concret;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CastraBus.Api.Controllers
{
    /// <summary>
    /// Classe Controller de Contratante
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ContratanteController : ControllerBase
    {
        private readonly Serilog.ILogger _logger;
        private readonly ContratanteServiceAsync<ContratanteVm, ContratanteEntity> contratanteService;

        /// <summary>
        /// Construtor da controller Empresa
        /// </summary>
        /// <param name="contratanteService">Injeção de dependência do serviço de Contratante</param>
        /// <param name="logger">Injeção de dependência do serviço de Serilog.ILogger</param>
        public ContratanteController(ContratanteServiceAsync<ContratanteVm, ContratanteEntity> contratanteService, Serilog.ILogger logger)
        {
            this.contratanteService = contratanteService;
            this._logger = logger;
        }

        /// <summary>
        /// Método para obter todas as Contratante
        /// </summary>
        /// <returns>Retorna todas as Contratante</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            try
            {
                this._logger.Information("Obtendo todas as Contratante");
                var result = await this.contratanteService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Get de Contratante, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para obter uma determinada Contratante
        /// </summary>
        /// <param name="id">Id da Contratante</param>
        /// <returns>Retorna um objeto Contratante</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(Int64 id)
        {
            try
            {
                this._logger.Information($"Obtendo uma determinada Contratante {id}");
                var result = await this.contratanteService.GetOne(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Get de Contratante, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para criar uma Contratante
        /// </summary>
        /// <param name="contratante">Objeto para inserir uma Contratante</param>
        /// <returns>Retorna um objeto DataResult</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] ContratanteVm contratante)
        {
            try
            {
                return Ok(await this.contratanteService.Insert(contratante));
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Insert de Contratante, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para atualizar uma Contratante
        /// </summary>
        /// <param name="id">Id da empresa a ser atualizado</param>
        /// <param name="contratante">Objeto para atualizar uma Contratante</param>
        /// <returns>Retorna um objeto DataResult</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(Int64 id, [FromBody] ContratanteVm contratante)
        {
            try
            {
                contratante.Id = id;
                return Ok(await this.contratanteService.Update(contratante));
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Update de Contratante, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para Remover uma Contratante
        /// </summary>
        /// <param name="id">Id da Contratante a ser removido</param>
        /// <returns>Retorna um objeto DataResult</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(Int64 id)
        {
            try
            {
                return Ok(await this.contratanteService.Delete(id));
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Delete de Contratante, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }
    }
}
