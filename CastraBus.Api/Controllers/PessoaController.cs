using CastraBus.Application.Entities.ViewModel;
using CastraBus.Application.Services.Concret;
using CastraBus.Infra.Data.Entities.Concret;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CastraBus.Api.Controllers
{
    /// <summary>
    /// Classe Controller de Pessoa
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly Serilog.ILogger _logger;
        private readonly PessoaServiceAsync<PessoaVm, PessoaEntity> pessoaService;

        /// <summary>
        /// Construtor da controller Pessoa
        /// </summary>
        /// <param name="pessoaService">Injeção de dependência do serviço de pessoa</param>
        /// <param name="logger">Injeção de dependência do serviço de Serilog.ILogger</param>
        public PessoaController(PessoaServiceAsync<PessoaVm, PessoaEntity> pessoaService, Serilog.ILogger logger)
        {
            this.pessoaService = pessoaService;
            _logger = logger;
        }

        /// <summary>
        /// Método para obter todas as pessoas
        /// </summary>
        /// <returns>Retorna todas as pessoas</returns>
        [Authorize]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            try
            {
                this._logger.Information("Obtendo todos os pessoa");
                var result = await this.pessoaService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Get de pessoas, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para obter uma determinada pessoa
        /// </summary>
        /// <param name="id">Id da pessoa</param>
        /// <returns>Retorna um objeto pessoa</returns>
        [Authorize]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(Int64 id)
        {
            try
            {
                this._logger.Information($"Obtendo um determinando pessoa {id}");
                var result = await this.pessoaService.GetOne(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Get de pessoas, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para obter uma lista de pessoas pelo tipoPessoaId
        /// </summary>
        /// <param name="id">Id TipoPessoa</param>
        /// <returns>Retorna uma lista de pessoas</returns>
        [Authorize]
        [HttpGet("GetPessoasByTipoPessoaId/{id}", Name = "GetPessoasByTipoPessoaId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPessoasByTipoPessoaId(Int64 id)
        {
            try
            {
                this._logger.Information($"Obtendo um determinando pessoa {id}");
                var result = await this.pessoaService.GetPessoasByTipoPessoaId(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Get de pessoas, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para obter uma determinada pessoa pelo CPF
        /// </summary>
        /// <param name="cpf">CPF da pessoa</param>
        /// <returns>Retorna um objeto pessoa</returns>
        [Authorize]
        [HttpGet("GetCPF/{cpf}", Name = "GetCPF")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCPF(string cpf)
        {
            try
            {
                this._logger.Information($"Obtendo um determinando pessoa pelo CPF {cpf}");
                var result = await this.pessoaService.GetCPF(cpf);
                return Ok(result);
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Get de pessoas, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para criar uma pessoa
        /// </summary>
        /// <param name="pessoa">Objeto para inserir uma pessoa</param>
        /// <returns>Retorna um objeto DataResult</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] PessoaVm pessoa)
        {
            try
            {
                return Ok(await this.pessoaService.Insert(pessoa));
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Insert de pessoa, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para atualizar uma pessoa
        /// </summary>
        /// <param name="id">Id da pessoa a ser atualizado</param>
        /// <param name="pessoa">Objeto para atualizar uma pessoa</param>
        /// <returns>Retorna um objeto DataResult</returns>
        [Authorize]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(Int64 id, [FromBody] PessoaVm pessoa)
        {
            try
            {
                pessoa.Id = id;
                return Ok(await this.pessoaService.Update(pessoa));
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Update de pessoa, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para Remover uma pessoa
        /// </summary>
        /// <param name="id">Id da pessoa a ser removido</param>
        /// <returns>Retorna um objeto DataResult</returns>
        [Authorize]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(Int64 id)
        {
            try
            {
                return Ok(await this.pessoaService.Delete(id));
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Delete de pessoa, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }
    }
}
