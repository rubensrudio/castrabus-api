using CastraBus.Application.Entities.ViewModel;
using CastraBus.Application.Services.Concret;
using CastraBus.Infra.Data.Entities.Concret;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CastraBus.Api.Controllers
{
    /// <summary>
    /// Classe Controller de Perfil
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilController : ControllerBase
    {
        private readonly Serilog.ILogger _logger;
        private readonly PerfilServiceAsync<PerfilVm, PerfilEntity> perfilService;

        /// <summary>
        /// Construtor da controller Perfil
        /// </summary>
        /// <param name="perfilService">Injeção de dependência do serviço de perfil</param>
        /// <param name="logger">Injeção de dependência do serviço de Serilog.ILogger</param>
        public PerfilController(PerfilServiceAsync<PerfilVm, PerfilEntity> perfilService, Serilog.ILogger logger)
        {
            this.perfilService = perfilService;
            _logger = logger;
        }

        /// <summary>
        /// Método para obter todos os perfil
        /// </summary>
        /// <returns>Retorna todos os perfil</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            try
            {
                this._logger.Information("Obtendo todos os perfil");
                var result = await this.perfilService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Get de perfil, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para obter um determinando perfil
        /// </summary>
        /// <param name="id">Id do perfil</param>
        /// <returns>Retorna um objeto perfil</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(Int64 id)
        {
            try
            {
                this._logger.Information($"Obtendo um determinando perfil {id}");
                var result = await this.perfilService.GetOne(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Get de perfil, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para obter todos os perfil
        /// </summary>
        /// <param name="id">Id da Empresa</param>
        /// <returns>Retorna todos os perfil baseado no id da empresa</returns>
        [HttpGet("GetPerfilByEmpresa/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPerfilByEmpresa(Int64 id)
        {   
            try
            {
                this._logger.Information($"Obtendo um determinando perfil baseado numa empresa {id}");
                var result = await this.perfilService.GetPerfilByEmpresa(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Get de perfil, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para criar um perfil
        /// </summary>
        /// <param name="perfil">Objeto para inserir um perfil</param>
        /// <returns>Retorna um objeto DataResult</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] PerfilVm perfil)
        {
            try
            {
                return Ok(await this.perfilService.Insert(perfil));
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Insert de perfil, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para atualizar um perfil
        /// </summary>
        /// <param name="id">Id do perfil a ser atualizado</param>
        /// <param name="perfil">Objeto para atualizar um perfil</param>
        /// <returns>Retorna um objeto DataResult</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(Int64 id, [FromBody] PerfilVm perfil)
        {
            try
            {
                perfil.Id = id;
                return Ok(await this.perfilService.Update(perfil));
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Update de perfil, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para Remover um perfil
        /// </summary>
        /// <param name="id">Id do perfil a ser removido</param>
        /// <returns>Retorna um objeto DataResult</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(Int64 id)
        {
            try
            {
                return Ok(await this.perfilService.Delete(id));
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Delete de perfil, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }
    }
}
