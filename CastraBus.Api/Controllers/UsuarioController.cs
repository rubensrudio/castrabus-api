using CastraBus.Application.Entities.ViewModel;
using CastraBus.Application.Services.Concret;
using CastraBus.Infra.Data.Entities.Concret;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CastraBus.Api.Controllers
{
    /// <summary>
    /// Classe Controller de Usuario
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly Serilog.ILogger _logger;
        private readonly UsuarioServiceAsync<UsuarioVm, UsuarioEntity> usuarioService;

        /// <summary>
        /// Construtor da controller Usuario
        /// </summary>
        /// <param name="usuarioService">Injeção de dependência do serviço de Usuario</param>
        public UsuarioController(UsuarioServiceAsync<UsuarioVm, UsuarioEntity> usuarioService, Serilog.ILogger logger)
        {
            this.usuarioService = usuarioService;
            this._logger = logger;
        }

        /// <summary>
        /// Método para obter todos os Usuario
        /// </summary>
        /// <returns>Retorna todos os Usuario</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            try
            {
                this._logger.Information("Obtendo todos os Usuarios");
                var result = await this.usuarioService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Get de Usuario, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para obter um determinando Usuario
        /// </summary>
        /// <param name="id">Id do Usuario</param>
        /// <returns>Retorna um objeto Usuario</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(Int64 id)
        {
            try
            {
                this._logger.Information($"Obtendo o usuario {id}");
                var result = await this.usuarioService.GetOne(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Get de Usuario, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para criar um Usuario
        /// </summary>
        /// <param name="usuario">Objeto para inserir um Usuario</param>
        /// <returns>Retorna um objeto DataResult</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody]UsuarioVm usuario)
        {
            try
            {
                this._logger.Information("Criando o Usuario");
                return Ok(await this.usuarioService.Insert(usuario));
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Post de Usuario, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para atualizar um Usuario
        /// </summary>
        /// <param name="id">Id do Usuario a ser atualizado</param>
        /// <param name="usuario">Objeto para atualizar um Usuario</param>
        /// <returns>Retorna um objeto DataResult</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(Int64 id, [FromBody] UsuarioVm usuario)
        {
            try
            {
                this._logger.Information("Atualizando usuario");
                usuario.Id = id;
                return Ok(await this.usuarioService.Update(usuario));
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Update de Usuario, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para Remover um Usuario
        /// </summary>
        /// <param name="id">Id do Usuario a ser removido</param>
        /// <returns>Retorna um objeto DataResult</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(Int64 id)
        {
            try
            {
                this._logger.Information($"Removendo usuario {id}");
                return Ok(await this.usuarioService.Delete(id));
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Delete de Usuario, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }
    }
}
