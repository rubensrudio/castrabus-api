using CastraBus.Application.Entities.ViewModel;
using CastraBus.Application.Services.Concret;
using CastraBus.Infra.Data.Entities.Concret;
using DinkToPdf;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace CastraBus.Api.Controllers
{
    /// <summary>
    /// Classe Controller de Receita
    /// </summary>
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ReceitaController : ControllerBase
    {
        private readonly Serilog.ILogger _logger;
        private readonly PdfServiceAsync pdfService;
        private readonly ReceitaServiceAsync<ReceitaVm, ReceitaEntity> receitaService;

        /// <summary>
        /// Construtor da controller Receita
        /// </summary>
        /// <param name="pdfService">Injeção de dependência do serviço de PdfService</param>
        /// <param name="receitaService">Injeção de dependência do serviço de Receita</param>
        /// <param name="logger">Injeção de dependência do serviço de Serilog.ILogger</param>
        public ReceitaController(PdfServiceAsync pdfService, ReceitaServiceAsync<ReceitaVm, ReceitaEntity> receitaService, Serilog.ILogger logger)
        {
            this._logger = logger;
            this.pdfService = pdfService;
            this.receitaService = receitaService;
        }

        /// <summary>
        /// Método para obter todas as Receitas
        /// </summary>
        /// <returns>Retorna todas as Receitas</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            try
            {
                this._logger.Information("Obtendo todas as Receitas");
                var result = await this.receitaService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Get de Receita, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para obter um determinando Receita
        /// </summary>
        /// <param name="id">Id do Receita</param>
        /// <returns>Retorna um objeto Receita</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(Int64 id)
        {
            try
            {
                this._logger.Information($"Obtendo um determinando Receita {id}");
                var result = await this.receitaService.GetOne(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Get de Receita, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para criar um Receita
        /// </summary>
        /// <param name="Receita">Objeto para inserir um Receita</param>
        /// <returns>Retorna um objeto DataResult</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] ReceitaVm Receita)
        {
            try
            {
                return Ok(await this.receitaService.Insert(Receita));
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Insert de Receita, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para atualizar um Receita
        /// </summary>
        /// <param name="id">Id do Receita a ser atualizado</param>
        /// <param name="Receita">Objeto para atualizar um Receita</param>
        /// <returns>Retorna um objeto DataResult</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(Int64 id, [FromBody] ReceitaVm Receita)
        {
            try
            {
                Receita.Id = id;
                return Ok(await this.receitaService.Update(Receita));
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Update de Receita, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para Remover um Receita
        /// </summary>
        /// <param name="id">Id do Receita a ser removido</param>
        /// <returns>Retorna um objeto DataResult</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(Int64 id)
        {
            try
            {
                return Ok(await this.receitaService.Delete(id));
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Delete de Receita, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para PDF da Receita
        /// </summary>
        /// <param name="Id">Id do Atendimento</param>
        /// <returns>Retorna um PDF da receita</returns>
        [HttpGet("ReceitaPdf/{Id}", Name = "ReceitaPdf")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ReceitaPdf(Int64 Id)
        {
            try
            {
                this._logger.Information("Obtendo a agenda de uma campanha");
                var receitaPdf = await this.receitaService.GetReceitaPdf(Id);
                var pdf = this.pdfService.GetPdfReceita(receitaPdf);

                return File(pdf, "application/pdf", "receita.pdf");
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo GetAgendaCampanha de agendamento, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }
    }
}
