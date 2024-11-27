using CastraBus.Application.Entities.ViewModel;
using CastraBus.Application.Services.Concret;
using CastraBus.Infra.Data.Entities.Concret;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CastraBus.Api.Controllers
{
    /// <summary>
    /// Classe Controller de Doença
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DoencaController : ControllerBase
    {
        private readonly Serilog.ILogger _logger;
        private readonly DoencaServiceAsync<DoencaVm, DoencaEntity> doencaService;

        /// <summary>
        /// Construtor da controller Doença
        /// </summary>
        /// <param name="doencaService">Injeção de dependência do serviço de Doença</param>
        /// <param name="logger">Injeção de dependência do serviço de Serilog.ILogger</param>
        public DoencaController(DoencaServiceAsync<DoencaVm, DoencaEntity> doencaService, Serilog.ILogger logger)
        {
            this.doencaService = doencaService;
            _logger = logger;
        }

        /// <summary>
        /// Método para obter todos os Doença
        /// </summary>
        /// <returns>Retorna todos os Doença</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            try
            {
                this._logger.Information("Obtendo todos os Doença");
                var result = await this.doencaService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Get de Doença, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para obter um determinando Doença
        /// </summary>
        /// <param name="id">Id do Doença</param>
        /// <returns>Retorna um objeto Doença</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(Int64 id)
        {
            try
            {
                this._logger.Information($"Obtendo um determinando Doença {id}");
                var result = await this.doencaService.GetOne(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Get de Doença, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para criar uma Doença
        /// </summary>
        /// <param name="doenca">Objeto para inserir uma Doença</param>
        /// <returns>Retorna um objeto DataResult</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] DoencaVm doenca)
        {
            try
            {
                return Ok(await this.doencaService.Insert(doenca));
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Insert de Doença, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para atualizar uma Doença
        /// </summary>
        /// <param name="id">Id do Doença a ser atualizado</param>
        /// <param name="tipoEspecie">Objeto para atualizar uma Doença</param>
        /// <returns>Retorna um objeto DataResult</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(Int64 id, [FromBody] DoencaVm doenca)
        {
            try
            {
                doenca.Id = id;
                return Ok(await this.doencaService.Update(doenca));
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Update de Doença, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para Remover um Doença
        /// </summary>
        /// <param name="id">Id do Doença a ser removido</param>
        /// <returns>Retorna um objeto DataResult</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(Int64 id)
        {
            try
            {
                return Ok(await this.doencaService.Delete(id));
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Delete de Doença, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }
    }
}
