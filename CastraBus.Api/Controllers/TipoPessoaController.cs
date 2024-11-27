using CastraBus.Application.Entities.ViewModel;
using CastraBus.Application.Services.Concret;
using CastraBus.Infra.Data.Entities.Concret;
using Microsoft.AspNetCore.Mvc;

namespace CastraBus.Api.Controllers
{
    /// <summary>
    /// Classe Controller de Tipo Pessoa
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TipoPessoaController : ControllerBase
    {
        private readonly Serilog.ILogger _logger;
        private readonly TipoPessoaServiceAsync<TipoPessoaVm, TipoPessoaEntity> tipoPessoaService;

        /// <summary>
        /// Construtor da controller Tipo Pessoa
        /// </summary>
        /// <param name="tipoPessoaService">Injeção de dependência do serviço de Tipo Pessoa</param>
        public TipoPessoaController(TipoPessoaServiceAsync<TipoPessoaVm, TipoPessoaEntity> tipoPessoaService, Serilog.ILogger logger)
        {
            this.tipoPessoaService = tipoPessoaService;
            this._logger = logger;
        }

        /// <summary>
        /// Método para obter todos os Tipo Pessoa
        /// </summary>
        /// <returns>Retorna todos os Tipo Pessoa</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            try
            {
                this._logger.Information("Obtendo todos os Tipo Pessoa");
                var result = await this.tipoPessoaService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Get de Tipo Pessoa, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para obter um determinando Tipo Pessoa
        /// </summary>
        /// <param name="id">Id do Tipo Pessoa</param>
        /// <returns>Retorna um objeto Tipo Pessoa</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(Int64 id)
        {
            try
            {
                this._logger.Information($"obtendo um determinando Tipo Pessoa {id}");
                var result = await this.tipoPessoaService.GetOne(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Get de Tipo Pessoa, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para criar um Tipo Pessoa
        /// </summary>
        /// <param name="tipoPessoa">Objeto para inserir um Tipo Pessoa</param>
        /// <returns>Retorna um objeto DataResult</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] TipoPessoaVm tipoPessoa)
        {
            try
            {
                this._logger.Information("Criando um Tipo Pessoa");
                return Ok(await this.tipoPessoaService.Insert(tipoPessoa));
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Post de Tipo Pessoa, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para atualizar um Tipo Pessoa
        /// </summary>
        /// <param name="id">Id do Tipo Pessoa a ser atualizado</param>
        /// <param name="tipoPessoa">Objeto para atualizar um Tipo Pessoa</param>
        /// <returns>Retorna um objeto DataResult</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(Int64 id, [FromBody] TipoPessoaVm tipoPessoa)
        {
            try
            {
                this._logger.Information($"Atualizando um Tipo Pessoa {id}");
                tipoPessoa.Id = id;
                return Ok(await this.tipoPessoaService.Update(tipoPessoa));
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Update de Tipo Pessoa, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para Remover um Tipo Pessoa
        /// </summary>
        /// <param name="id">Id do Tipo Pessoa a ser removido</param>
        /// <returns>Retorna um objeto DataResult</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(Int64 id)
        {
            try
            {
                this._logger.Information($"Removendo um Tipo Pessoa {id}");
                return Ok(await this.tipoPessoaService.Delete(id));
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Delete de Tipo Pessoa, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }
    }
}
