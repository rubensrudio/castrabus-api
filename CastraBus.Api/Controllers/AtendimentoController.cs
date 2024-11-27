using CastraBus.Application.Entities.ViewModel;
using CastraBus.Application.Services.Concret;
using CastraBus.Infra.Data.Entities.Concret;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CastraBus.Api.Controllers
{
    /// <summary>
    /// Classe Controller de Atendimento
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AtendimentoController : ControllerBase
    {
        private readonly Serilog.ILogger _logger;
        private readonly AtendimentoServiceAsync<AtendimentoVm, AtendimentoEntity> _atendimentoService;

        /// <summary>
        /// Construtor da controller Atendimento
        /// </summary>
        /// <param name="atendimentoService">Injeção de dependência do serviço de atendimento</param>
        /// <param name="logger">Injeção de dependência do serviço de Serilog.ILogger</param>
        public AtendimentoController(AtendimentoServiceAsync<AtendimentoVm, AtendimentoEntity> atendimentoService, Serilog.ILogger logger)
        {
            _logger = logger;
            this._atendimentoService = atendimentoService;
        }

        /// <summary>
        /// Método para obter todos os atendimentos
        /// </summary>
        /// <returns>Retorna todos os atendimentos</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            try
            {
                this._logger.Information("Obtendo todos os atendimentos");
                var result = await this._atendimentoService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Get de atendimento, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para obter um determinando atendimento
        /// </summary>
        /// <param name="id">Id do atendimento</param>
        /// <returns>Retorna um objeto atendimento</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(Int64 id)
        {
            try
            {
                this._logger.Information($"Obtendo um determinando atendimento {id}");
                var result = await this._atendimentoService.GetOne(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Get de atendimento, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para criar um atendimento
        /// </summary>
        /// <param name="atendimento">Objeto para inserir um atendimento</param>
        /// <returns>Retorna um objeto DataResult</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] AtendimentoVm atendimento)
        {
            try
            {
                return Ok(await this._atendimentoService.Insert(atendimento));
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Insert de atendimento, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para atualizar um atendimento
        /// </summary>
        /// <param name="id">Id do atendimento a ser atualizado</param>
        /// <param name="atendimento">Objeto para atualizar um atendimento</param>
        /// <returns>Retorna um objeto DataResult</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(Int64 id, [FromBody] AtendimentoVm atendimento)
        {
            try
            {
                atendimento.Id = id;
                return Ok(await this._atendimentoService.Update(atendimento));
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Update de atendimento, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para Remover um atendimento
        /// </summary>
        /// <param name="id">Id do atendimento a ser removido</param>
        /// <returns>Retorna um objeto DataResult</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(Int64 id)
        {
            try
            {
                return Ok(await this._atendimentoService.Delete(id));
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Delete de atendimento, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para obter o atendimento
        /// </summary>
        /// <param name="senhaAtendimento">Senha Criada para o Atendimento</param>
        /// <returns>Retorna o Id da senha gerada</returns>
        [HttpGet("GetObterAtendimentoBySenhaAtendimento/{senhaAtendimento}", Name = "GetObterAtendimentoBySenhaAtendimento")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetObterAtendimentoBySenhaAtendimento(string senhaAtendimento)
        {
            try
            {
                this._logger.Information($"Obtendo atendimento para senha: {senhaAtendimento}");
                return Ok(await this._atendimentoService.GetObterAtendimentoBySenhaAtendimento(senhaAtendimento));
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo GetObterAtendimentoBySenhaAtendimento de agendamento, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para atualizar o pre-operatorio
        /// </summary>
        /// <param name="atendimento">Objeto para atualizar o atendimento para pre-operatorio</param>
        /// <returns>Retorna um objeto DataResult</returns>
        [HttpPost("PreOperatorio", Name = "PreOperatorio")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PreOperatorio([FromBody] AtendimentoVm atendimento)
        {
            try
            {
                this._logger.Information($"Método para atualizar o pre-operatorio");
                return Ok(await this._atendimentoService.PreOperatorio(atendimento));
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo PreOperatorio de atendimento, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para atualizar o trans-operatorio
        /// </summary>
        /// <param name="atendimento">Objeto para atualizar o atendimento para trans-operatorio</param>
        /// <returns>Retorna um objeto DataResult</returns>
        [HttpPost("TransOperatorio", Name = "TransOperatorio")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> TransOperatorio([FromBody] AtendimentoVm atendimento)
        {
            try
            {
                this._logger.Information($"Método para atualizar o trans-operatorio");
                return Ok(await this._atendimentoService.TransOperatorio(atendimento));
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo TransOperatorio de atendimento, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para atualizar o pos-operatorio
        /// </summary>
        /// <param name="posOperatorio">Objeto para atualizar o atendimento para pos-operatorio</param>
        /// <returns>Retorna um objeto DataResult</returns>
        [HttpPost("PosOperatorio", Name = "PosOperatorio")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PosOperatorio([FromBody] PosOperatorioVm posOperatorio)
        {
            try
            {
                this._logger.Information($"Método para atualizar o pos-operatorio");
                return Ok(await this._atendimentoService.PosOperatorio(posOperatorio));
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo PosOperatorio de atendimento, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }
    }
}
