using CastraBus.Application.Entities.ViewModel;
using CastraBus.Application.Services.Concret;
using CastraBus.Infra.Data.Entities.Concret;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CastraBus.Api.Controllers
{
    /// <summary>
    /// Classe Controller de Permissao
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PermissaoController : ControllerBase
    {
        private readonly Serilog.ILogger _logger;
        private readonly PermissaoServiceAsync<PermissaoVm, PermissaoEntity> permissaoService;

        /// <summary>
        /// Construtor da controller Perfil
        /// </summary>
        /// <param name="permissaoService">Injeção de dependência do serviço de Permissao</param>
        /// <param name="logger">Injeção de dependência do serviço de Serilog.ILogger</param>
        public PermissaoController(PermissaoServiceAsync<PermissaoVm, PermissaoEntity> permissaoService, Serilog.ILogger logger)
        {
            this.permissaoService = permissaoService;
            _logger = logger;
        }

        /// <summary>
        /// Método para obter todos os Permissao
        /// </summary>
        /// <returns>Retorna todos os Permissao</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            try
            {
                this._logger.Information("Obtendo todos os Permissao");
                var result = await this.permissaoService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Get de Permissao, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para obter um determinando Permissao
        /// </summary>
        /// <param name="id">Id do Permissao</param>
        /// <returns>Retorna um objeto Permissao</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(Int64 id)
        {
            try
            {
                this._logger.Information($"Obtendo um determinando Permissao {id}");
                var result = await this.permissaoService.GetOne(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Get de Permissao, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para criar um Permissao
        /// </summary>
        /// <param name="permissao">Objeto para inserir um Permissao</param>
        /// <returns>Retorna um objeto DataResult</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] PermissaoVm permissao)
        {
            try
            {
                return Ok(await this.permissaoService.Insert(permissao));
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Insert de Permissao, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para atualizar um Permissao
        /// </summary>
        /// <param name="id">Id do perfil a ser atualizado</param>
        /// <param name="permissao">Objeto para atualizar um Permissao</param>
        /// <returns>Retorna um objeto DataResult</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(Int64 id, [FromBody] PermissaoVm permissao)
        {
            try
            {
                permissao.Id = id;
                return Ok(await this.permissaoService.Update(permissao));
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Update de Permissao, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para Remover um Permissao
        /// </summary>
        /// <param name="id">Id do Permissao a ser removido</param>
        /// <returns>Retorna um objeto DataResult</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(Int64 id)
        {
            try
            {
                return Ok(await this.permissaoService.Delete(id));
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Delete de Permissao, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }
    }
}
