using CastraBus.Application.Entities.ViewModel;
using CastraBus.Application.Services.Concret;
using CastraBus.Infra.Data.Entities.Concret;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CastraBus.Api.Controllers
{
    /// <summary>
    /// Classe Controller de Arquivo
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ArquivoController : ControllerBase
    {
        private readonly Serilog.ILogger _logger;
        private readonly ArquivoServiceAsync<ArquivoVm, ArquivoEntity> arquivoService;

        /// <summary>
        /// Construtor da controller Arquivo
        /// </summary>
        /// <param name="arquivoService">Injeção de dependência do serviço de arquivo</param>
        /// <param name="logger">Injeção de dependência do serviço de Serilog.ILogger</param>
        public ArquivoController(ArquivoServiceAsync<ArquivoVm, ArquivoEntity> arquivoService, Serilog.ILogger logger)
        {
            this.arquivoService = arquivoService;
            _logger = logger;
        }

        /// <summary>
        /// Método para Obter todos os arquivos
        /// </summary>
        /// <returns>Retorna todos os arquivos</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            try
            {
                this._logger.Information("Obtendo todos os arquivos");
                var result = await this.arquivoService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Get de arquivos, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para Obter um determinando arquivo
        /// </summary>
        /// <param name="id">Id do arquivo</param>
        /// <returns>Retorna um objeto arquivo</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(Int64 id)
        {
            try
            {
                this._logger.Information($"Obtendo um determinando arquivo {id}");
                var result = await this.arquivoService.GetOne(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Get de arquivos, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para criar um arquivo
        /// </summary>
        /// <param name="arquivo">Objeto para inserir um arquivo</param>
        /// <returns>Retorna um objeto DataResult</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] ArquivoVm arquivo)
        {
            try
            {
                return Ok(await this.arquivoService.Insert(arquivo));
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Insert de um arquivos, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para atualizar um arquivo
        /// </summary>
        /// <param name="id">Id do arquivo a ser atualizado</param>
        /// <param name="arquivo">Objeto para atualizar um arquivo</param>
        /// <returns>Retorna um objeto DataResult</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(Int64 id, [FromBody] ArquivoVm arquivo)
        {
            try
            {
                arquivo.Id = id;
                return Ok(await this.arquivoService.Update(arquivo));
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Updare de arquivos, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para Remover um arquivo
        /// </summary>
        /// <param name="id">Id do arquivo a ser removido</param>
        /// <returns>Retorna um objeto DataResult</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(Int64 id)
        {
            try
            {
                return Ok(await this.arquivoService.Delete(id));
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Delete de arquivos, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }
    }
}
