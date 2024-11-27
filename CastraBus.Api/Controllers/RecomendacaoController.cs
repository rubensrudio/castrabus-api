using CastraBus.Application.Entities.ViewModel;
using CastraBus.Application.Services.Concret;
using CastraBus.Infra.Data.Entities.Concret;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CastraBus.Api.Controllers
{
    /// <summary>
    /// Classe Controller de Recomendacao
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RecomendacaoController : ControllerBase
    {
        private readonly Serilog.ILogger _logger;
        private readonly RecomendacaoServiceAsync<RecomendacaoVm, RecomendacaoEntity> recomendacaoService;

        /// <summary>
        /// Construtor da controller Recomendacao
        /// </summary>
        /// <param name="recomendacaoService">Injeção de dependência do serviço de Recomendacao</param>
        /// <param name="logger">Injeção de dependência do serviço de Serilog.ILogger</param>
        public RecomendacaoController(RecomendacaoServiceAsync<RecomendacaoVm, RecomendacaoEntity> recomendacaoService, Serilog.ILogger logger)
        {
            this.recomendacaoService = recomendacaoService;
            this._logger = logger;
        }

        /// <summary>
        /// Método para obter todos os Recomendacao
        /// </summary>
        /// <returns>Retorna todos os Recomendacao</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            try
            {
                this._logger.Information("Obtendo todos os Recomendacao");
                var result = await this.recomendacaoService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Get de Recomendacao, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para obter um determinando Recomendacao
        /// </summary>
        /// <param name="id">Id do Recomendacao</param>
        /// <returns>Retorna um objeto Recomendacao</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(Int64 id)
        {
            try
            {
                this._logger.Information($"Obtendo um determinando Recomendacao {id}");
                var result = await this.recomendacaoService.GetOne(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Get de Recomendacao, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para criar um Recomendacao
        /// </summary>
        /// <param name="recomendacao">Objeto para inserir um Recomendacao</param>
        /// <returns>Retorna um objeto DataResult</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] RecomendacaoVm recomendacao)
        {
            try
            {
                return Ok(await this.recomendacaoService.Insert(recomendacao));
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Insert de Recomendacao, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para atualizar um Recomendacao
        /// </summary>
        /// <param name="id">Id do Recomendacao a ser atualizado</param>
        /// <param name="recomendacao">Objeto para atualizar um Recomendacao</param>
        /// <returns>Retorna um objeto DataResult</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(Int64 id, [FromBody] RecomendacaoVm recomendacao)
        {
            try
            {
                recomendacao.Id = id;
                return Ok(await this.recomendacaoService.Update(recomendacao));
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Update de Recomendacao, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para Remover um Recomendacao
        /// </summary>
        /// <param name="id">Id do Recomendacao a ser removido</param>
        /// <returns>Retorna um objeto DataResult</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(Int64 id)
        {
            try
            {
                return Ok(await this.recomendacaoService.Delete(id));
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Delete de Recomendacao, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }
    }
}
