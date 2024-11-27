using CastraBus.Application.Entities.ViewModel;
using CastraBus.Application.Services.Concret;
using CastraBus.Infra.Data.Entities.Concret;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CastraBus.Api.Controllers
{
    /// <summary>
    /// Classe Controller de Medicamento
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MedicamentoController : ControllerBase
    {
        private readonly Serilog.ILogger _logger;
        private readonly MedicamentoServiceAsync<MedicamentoVm, MedicacaoEntity> medicamentoService;

        /// <summary>
        /// Construtor da controller Medicamento
        /// </summary>
        /// <param name="medicamentoService">Injeção de dependência do serviço de Medicamento</param>
        /// <param name="logger">Injeção de dependência do serviço de Serilog.ILogger</param>
        public MedicamentoController(MedicamentoServiceAsync<MedicamentoVm, MedicacaoEntity> medicamentoService, Serilog.ILogger logger)
        {
            this.medicamentoService = medicamentoService;
            this._logger = logger;
        }

        /// <summary>
        /// Método para obter todos os Medicamento
        /// </summary>
        /// <returns>Retorna todos os Medicamento</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            try
            {
                this._logger.Information("Obtendo todos os Medicamento");
                var result = await this.medicamentoService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Get de Medicamento, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para obter um determinando Medicamento
        /// </summary>
        /// <param name="id">Id do Medicamento</param>
        /// <returns>Retorna um objeto Medicamento</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(Int64 id)
        {
            try
            {
                this._logger.Information($"Obtendo um determinando Medicamento {id}");
                var result = await this.medicamentoService.GetOne(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Get de Medicamento, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para criar um Medicamento
        /// </summary>
        /// <param name="medicamento">Objeto para inserir um Medicamento</param>
        /// <returns>Retorna um objeto DataResult</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] MedicamentoVm medicamento)
        {
            try
            {
                return Ok(await this.medicamentoService.Insert(medicamento));
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Insert de Medicamento, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para atualizar um Medicamento
        /// </summary>
        /// <param name="id">Id do Medicamento a ser atualizado</param>
        /// <param name="medicamento">Objeto para atualizar um Medicamento</param>
        /// <returns>Retorna um objeto DataResult</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(Int64 id, [FromBody] MedicamentoVm medicamento)
        {
            try
            {
                medicamento.Id = id;
                return Ok(await this.medicamentoService.Update(medicamento));
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Update de Medicamento, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para Remover um Medicamento
        /// </summary>
        /// <param name="id">Id do Medicamento a ser removido</param>
        /// <returns>Retorna um objeto DataResult</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(Int64 id)
        {
            try
            {
                return Ok(await this.medicamentoService.Delete(id));
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Delete de Medicamento, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para obter todos os medicamentos baseado no peso e tipo da especie
        /// </summary>
        /// <param name="peso">Peso do Animal</param>
        /// <param name="tipoEspecie">Tipo da sua especie</param>
        /// <returns>Retorna uma lista de medicamentos</returns>
        [HttpGet("GetMedicamentoByPesoAndTipoEspecie", Name = "GetMedicamentoByPesoAndTipoEspecie")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetMedicamentoByPesoAndTipoEspecie([FromQuery(Name = "peso")] Int64 peso
                                                                          , [FromQuery(Name = "tipoEspecie")] Int64 tipoEspecie)
        {
            try
            {
                this._logger.Information("Obter medicamentos Filtrados");
                return Ok(await this.medicamentoService.GetMedicamentoByPesoAndTipoEspecie(peso, tipoEspecie));
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo GetMedicamentoByPesoAndTipoEspecie de medicamentos, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }
    }
}
