using CastraBus.Application.Entities.ViewModel;
using CastraBus.Application.Services.Concret;
using CastraBus.Infra.Data.Entities.Concret;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CastraBus.Api.Controllers
{
    /// <summary>
    /// Classe Controller de Campanha
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CampanhaController : ControllerBase
    {
        private readonly Serilog.ILogger _logger;
        private readonly CampanhaServiceAsync<CampanhaVm, CampanhaEntity> campanhaService;

        /// <summary>
        /// Construtor da controller Campanha
        /// </summary>
        /// <param name="campanhaService">Injeção de dependência do serviço de Campanha</param>
        /// <param name="logger">Injeção de dependência do serviço de Serilog.ILogger</param>
        public CampanhaController(CampanhaServiceAsync<CampanhaVm, CampanhaEntity> campanhaService, Serilog.ILogger logger)
        {
            this.campanhaService = campanhaService;
            _logger = logger;
        }

        /// <summary>
        /// Método para Obter todas as campanha
        /// </summary>
        /// <returns>Retorna todas as campanha</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            try
            {
                this._logger.Information("Obtendo todas as campanha");
                var result = await this.campanhaService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Get de campanha mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para Obter todas as campanha validas
        /// </summary>
        /// <returns>Retorna todas as campanha validas</returns>
        [HttpGet("GetCampanhasValidas", Name = "GetCampanhasValidas")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCampanhasValidas()
        {
            try
            {
                this._logger.Information("Obtendo todas as campanha validas");
                var result = await this.campanhaService.GetCampanhasValidas();
                return Ok(result);
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Get de CampanhasValidas mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para Obter uma determinada campanha
        /// </summary>
        /// <param name="id">Id do Campanha</param>
        /// <returns>Retorna um objeto Campanha</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(Int64 id)
        {
            try
            {
                this._logger.Information($"Obtendo uma determinada campanha {id}");
                var result = await this.campanhaService.GetOne(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Get de campanha mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para criar uma campanha
        /// </summary>
        /// <param name="configuracao">Objeto para inserir uma campanha</param>
        /// <returns>Retorna um objeto DataResult</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] CampanhaVm configuracao)
        {
            try
            {
                return Ok(await this.campanhaService.Insert(configuracao));
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Insert de campanha mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para atualizar uma campanha
        /// </summary>
        /// <param name="id">Id da campanha a ser atualizado</param>
        /// <param name="configuracao">Objeto para atualizar uma campanha</param>
        /// <returns>Retorna um objeto DataResult</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(Int64 id, [FromBody] CampanhaVm configuracao)
        {
            
            try
            {
                configuracao.Id = id;
                return Ok(await this.campanhaService.Update(configuracao));
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Update de campanha mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para Remover uma campanha
        /// </summary>
        /// <param name="id">Id da campanha a ser removido</param>
        /// <returns>Retorna um objeto DataResult</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(Int64 id)
        {
            
            try
            {
                return Ok(await this.campanhaService.Delete(id));
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Delete de campanha mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }
    }
}
