using CastraBus.Application.Entities.ViewModel;
using CastraBus.Application.Services.Concret;
using CastraBus.Infra.Data.Entities.Concret;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CastraBus.Api.Controllers
{
    /// <summary>
    /// Classe Controller de Empresa
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly Serilog.ILogger _logger;
        private readonly EmpresaServiceAsync<EmpresaVm, EmpresaEntity> empresaService;

        /// <summary>
        /// Construtor da controller Empresa
        /// </summary>
        /// <param name="empresaService">Injeção de dependência do serviço de empresa</param>
        /// <param name="logger">Injeção de dependência do serviço de Serilog.ILogger</param>
        public EmpresaController(EmpresaServiceAsync<EmpresaVm, EmpresaEntity> empresaService, Serilog.ILogger logger)
        {
            this.empresaService = empresaService;
            this._logger = logger;
        }

        /// <summary>
        /// Método para obter todas as empresas
        /// </summary>
        /// <returns>Retorna todas as empresas</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            try
            {
                this._logger.Information("Obtendo todas as empresas");
                var result = await this.empresaService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Get de Empresa, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para obter uma determinada empresa
        /// </summary>
        /// <param name="id">Id da empresa</param>
        /// <returns>Retorna um objeto empresa</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(Int64 id)
        {
            try
            {
                this._logger.Information($"Obtendo uma determinada empresa {id}");
                var result = await this.empresaService.GetOne(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Get de empresa, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para criar uma empresa
        /// </summary>
        /// <param name="empresa">Objeto para inserir uma empresa</param>
        /// <returns>Retorna um objeto DataResult</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] EmpresaVm empresa)
        {
            try
            {
                return Ok(await this.empresaService.Insert(empresa));
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Insert de empresa, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para atualizar uma empresa
        /// </summary>
        /// <param name="id">Id da empresa a ser atualizado</param>
        /// <param name="empresa">Objeto para atualizar uma empresa</param>
        /// <returns>Retorna um objeto DataResult</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(Int64 id, [FromBody] EmpresaVm empresa)
        {
            try
            {
                empresa.Id = id;
                return Ok(await this.empresaService.Update(empresa));
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Update de empresa, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para Remover uma empresa
        /// </summary>
        /// <param name="id">Id da empresa a ser removido</param>
        /// <returns>Retorna um objeto DataResult</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(Int64 id)
        {
            try
            {
                return Ok(await this.empresaService.Delete(id));
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Delete de empresa, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }
    }
}
