using CastraBus.Application.Entities.ViewModel;
using CastraBus.Application.Services.Concret;
using CastraBus.Infra.Data.Entities.Concret;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CastraBus.Api.Controllers
{
    /// <summary>
    /// Classe Controller de Tipo Empresa
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TipoEmpresaController : ControllerBase
    {
        private readonly Serilog.ILogger _logger;
        private readonly TipoEmpresaServiceAsync<TipoEmpresaVm, TipoEmpresaEntity> _tipoEmpresaService;

        /// <summary>
        /// Construtor da controller Tipo Empresa
        /// </summary>
        /// <param name="tipoEmpresaService">Injeção de dependência do serviço de Tipo Empresa</param>
        /// <param name="logger">Injeção de dependência do serviço de Serilog.ILogger</param>
        public TipoEmpresaController(TipoEmpresaServiceAsync<TipoEmpresaVm, TipoEmpresaEntity> tipoEmpresaService, Serilog.ILogger logger)
        {
            this._tipoEmpresaService = tipoEmpresaService;
            this._logger = logger;
        }

        /// <summary>
        /// Método para Obter todos os Tipo Empresa
        /// </summary>
        /// <returns>Retorna todos os Tipo Empresa</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            try
            {
                this._logger.Information("Obtendo todos os Tipo Empresa");
                var result = await this._tipoEmpresaService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Get de Tipo Empresa, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para Obter um determinando Tipo Empresa
        /// </summary>
        /// <param name="id">Id do Tipo Empresa</param>
        /// <returns>Retorna um objeto Tipo Empresa</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(Int64 id)
        {
            try
            {
                this._logger.Information($"Obtendo um determinando Tipo Empresa {id}");
                var result = await this._tipoEmpresaService.GetOne(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Get de Tipo Empresa, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para criar um Tipo Empresa
        /// </summary>
        /// <param name="tipoEmpresa">Objeto para inserir um Tipo Empresa</param>
        /// <returns>Retorna um objeto DataResult</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] TipoEmpresaVm tipoEmpresa)
        {
            try
            {
                return Ok(await this._tipoEmpresaService.Insert(tipoEmpresa));
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Criar um Tipo Empresa, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para atualizar um Tipo Empresa
        /// </summary>
        /// <param name="id">Id do Tipo Empresa a ser atualizado</param>
        /// <param name="tipoEmpresa">Objeto para atualizar um Tipo Empresa</param>
        /// <returns>Retorna um objeto DataResult</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(Int64 id, [FromBody] TipoEmpresaVm tipoEmpresa)
        {
            try
            {
                tipoEmpresa.Id = id;
                return Ok(await this._tipoEmpresaService.Update(tipoEmpresa));
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Update de Tipo Empresa, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para Remover um Tipo Empresa
        /// </summary>
        /// <param name="id">Id do Tipo Empresa a ser removido</param>
        /// <returns>Retorna um objeto DataResult</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(Int64 id)
        {
            try
            {
                return Ok(await this._tipoEmpresaService.Delete(id));
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Delete de Tipo Empresa, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }
    }
}
