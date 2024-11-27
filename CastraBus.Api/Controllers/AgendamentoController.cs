using CastraBus.Application.Entities.ViewModel;
using CastraBus.Application.Services.Concret;
using CastraBus.Infra.Data.Entities.Concret;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CastraBus.Api.Controllers
{
    /// <summary>
    /// Classe Controller de Agendamento
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentoController : ControllerBase
    {
        private readonly Serilog.ILogger _logger;
        private readonly AgendamentoServiceAsync<AgendamentoVm, AgendamentoEntity> agendamentoService;

        /// <summary>
        /// Construtor da controller Agendamento
        /// </summary>
        /// <param name="agendamentoService">Injeção de dependência do serviço de agendamento</param>
        /// <param name="logger">Injeção de dependência do serviço de Serilog.ILogger</param>
        public AgendamentoController(AgendamentoServiceAsync<AgendamentoVm, AgendamentoEntity> agendamentoService, Serilog.ILogger logger)
        {
            this.agendamentoService = agendamentoService;
            _logger = logger;
        }

        /// <summary>
        /// Método para obter todos os agendamentos
        /// </summary>
        /// <returns>Retorna todos os agendamentos</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            try
            {
                this._logger.Information("Obtendo todos os agendamentos");
                var result = await this.agendamentoService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Get de agendamento, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para obter um determinando agendamento
        /// </summary>
        /// <param name="id">Id do agendamento</param>
        /// <returns>Retorna um objeto agendamento</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(Int64 id)
        {
            try
            {
                this._logger.Information($"Obtendo um determinando agendamento {id}");
                var result = await this.agendamentoService.GetOne(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Get de agendamento, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para criar um agendamento
        /// </summary>
        /// <param name="agendamento">Objeto para inserir um agendameto</param>
        /// <returns>Retorna um objeto DataResult</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] AgendamentoVm agendamento)
        {
            try
            {
                return Ok(await this.agendamentoService.Insert(agendamento));
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Insert de agendamento, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para atualizar um agendamento
        /// </summary>
        /// <param name="id">Id do agendamento a ser atualizado</param>
        /// <param name="agendamento">Objeto para atualizar um agendamento</param>
        /// <returns>Retorna um objeto DataResult</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(Int64 id, [FromBody] AgendamentoVm agendamento)
        {
            try
            {
                agendamento.Id = id;
                return Ok(await this.agendamentoService.Update(agendamento));
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Update de agendamento, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para Remover um agendamento
        /// </summary>
        /// <param name="id">Id do agendamento a ser removido</param>
        /// <returns>Retorna um objeto DataResult</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(Int64 id)
        {
            try
            {
                return Ok(await this.agendamentoService.Delete(id));
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Delete de agendamento, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para obter agenda da campanha
        /// </summary>
        /// <param name="campanhaId">Id da Campanha</param>
        /// <returns>Retorna um objeto com toda agenda da campanha</returns>
        [HttpGet("GetAgendaCampanha/{campanhaId}", Name = "GetAgendaCampanha")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAgendaCampanha(Int64 campanhaId)
        {
            try
            {
                this._logger.Information("Obtendo a agenda de uma campanha");
                return Ok(await this.agendamentoService.GetAgendaCampanha(campanhaId));
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo GetAgendaCampanha de agendamento, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para obter todos os agendamentos por data, campanha e empresa
        /// </summary>
        /// <param name="campanhaId">Id da campanha</param>
        /// <param name="empresaId">Id da empresa</param>
        /// <param name="data">Data do agedamento</param>
        /// <returns>Retorna uma lista de agendamentos do dia</returns>
        [HttpGet("GetAgendamentoByDataAndCampanhaAndEmpresa/{campanhaId}/{empresaId}/{data}", Name = "GetAgendamentoByDataAndCampanhaAndEmpresa")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAgendamentoByDataAndCampanhaAndEmpresa(Int64 campanhaId, Int64 empresaId, String data)
        {
            try
            {
                this._logger.Information("Obtendo todos os agendamentos por data, campanha e empresa");
                return Ok(await this.agendamentoService.GetAgendamentoByDataAndCampanhaAndEmpresa(campanhaId, empresaId, data));
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo GetAgendamentoByDataAndCampanhaAndEmpresa de agendamento, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para obter todos os agendamentos da campanha e empresa
        /// </summary>
        /// <param name="campanhaId">Id da campanha</param>
        /// <param name="empresaId">Id da empresa</param>
        /// <returns>Retorna uma lista de agendamentos da campanha</returns>
        [HttpGet("GetAgendamentoByCampanhaAndEmpresa/{campanhaId}/{empresaId}", Name = "GetAgendamentoByCampanhaAndEmpresa")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAgendamentoByCampanhaAndEmpresa(Int64 campanhaId, Int64 empresaId)
        {
            try
            {
                this._logger.Information("Obtendo todos os agendamentos da campanha e empresa");
                return Ok(await this.agendamentoService.GetAgendamentoByCampanhaAndEmpresa(campanhaId, empresaId));
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo GetAgendamentoByCampanhaAndEmpresa de agendamento, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para obter todos os agendamentos da pessoa
        /// </summary>
        /// <param name="pessoaId">Id da pessoa</param>
        /// <returns>Retorna uma lista de agendamentos da pessoa</returns>
        [HttpGet("GetAllMyAgendamentos/{pessoaId}", Name = "GetAllMyAgendamentos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllMyAgendamentos(Int64 pessoaId)
        {
            try
            {
                this._logger.Information("Obtendo todos os agendamentos da pessoa");
                return Ok(await this.agendamentoService.GetAllMyAgendamentos(pessoaId));
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo GetAllMyAgendamentos de agendamento, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para Verificar se o agendamento é valido
        /// </summary>
        /// <param name="animalId">Id da pessoa</param>
        /// <param name="campanhaId">Id da campanha</param>
        /// <returns>Retorna uma boolean informado se está valido ou nao o agendamento</returns>
        [HttpGet("VerificarAgendamento", Name = "VerificarAgendamento")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> VerificarAgendamento([FromQuery(Name = "animalId")]Int64 animalId, [FromQuery(Name = "campanhaId")] Int64 campanhaId)
        {
            try
            {
                this._logger.Information("Verificar se o agendamento é valido");
                return Ok(await this.agendamentoService.VerificarAgendamento(animalId, campanhaId));
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo VerificarAgendamento de agendamento, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para obter todos os agendamentos de uma campanha
        /// </summary>
        /// <param name="campanhaId">Id da campanha</param>
        /// <param name="data">Data de filtro</param>
        /// <param name="tutor">Nome do Tutor</param>
        /// <returns>Retorna uma lista de agendamentos</returns>
        [HttpGet("GetAgendamentosFiltered", Name = "GetAgendamentosFiltered")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAgendamentosFiltered([FromQuery(Name = "campanhaId")] string? campanhaId
                                                               , [FromQuery(Name = "data")] string? data
                                                               , [FromQuery(Name = "tutor")] string? tutor)
        {
            try
            {
                this._logger.Information("Obter Agendamentos Filtrados");
                return Ok(await this.agendamentoService.GetAgendamentosFiltered(campanhaId, data, tutor));
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo GetAgendamentosFiltered de agendamento, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para obter a senha do agendamento
        /// </summary>
        /// <param name="agendamentoId">Id da campanha</param>
        /// <returns>Retorna o Id da senha gerada</returns>
        [HttpGet("GerarSenha/{agendamentoId}", Name = "GerarSenha")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetGerarSenha(Int64 agendamentoId)
        {
            try
            {
                this._logger.Information($"Gerando senha para o agendamento: { agendamentoId }");
                var senha = await this.agendamentoService.GetGerarSenha(agendamentoId);
                return Ok(senha);
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo GetAgendamentosFiltered de agendamento, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }
    }
}
