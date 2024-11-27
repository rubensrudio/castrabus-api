using CastraBus.Application.Entities.ViewModel;
using CastraBus.Application.Services.Concret;
using CastraBus.Infra.Data.Entities.Concret;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace CastraBus.Api.Controllers
{
    /// <summary>
    /// Classe Controller de Animal
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly Serilog.ILogger _logger;
        private readonly AnimalServiceAsync<AnimalVm, AnimalEntity> animalService;

        /// <summary>
        /// Construtor da controller Animal
        /// </summary>
        /// <param name="animalService">Injeção de dependência do serviço de animal</param>
        /// <param name="logger">Injeção de dependência do serviço de Serilog.ILogger</param>
        public AnimalController(AnimalServiceAsync<AnimalVm, AnimalEntity> animalService, Serilog.ILogger logger)
        {
            this.animalService = animalService;
            _logger = logger;
        }

        /// <summary>
        /// Método para Obter todos os animais
        /// </summary>
        /// <returns>Retorna todos os animais</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            try
            {
                this._logger.Information("Obtendo todos os animais");
                var result = await this.animalService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Get de animais, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para Obter um determinando animal
        /// </summary>
        /// <param name="id">Id do animal</param>
        /// <returns>Retorna um objeto animal</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(Int64 id)
        {
            try
            {
                this._logger.Information($"Obtendo um determinando animal {id}");
                var result = await this.animalService.GetOne(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Get de animais, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para Obter uma lista de animal pelo Id Pessoa
        /// </summary>
        /// <param name="pessoaId">Id do Pessoa</param>
        /// <returns>Retorna uma lista de objetos animal</returns>
        [HttpGet("GetAnimalByPessoa/{pessoaId}", Name = "GetAnimalByPessoa")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAnimalByPessoa(Int64 pessoaId)
        {
            try
            {
                this._logger.Information($"Obtendo uma lista de animal pelo Id Pessoa {pessoaId}");
                var result = await this.animalService.GetAnimalByPessoa(pessoaId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo GetAnimalByPessoa de animais, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para criar um animal
        /// </summary>
        /// <param name="animal">Objeto para inserir um animal</param>
        /// <returns>Retorna um objeto DataResult</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] AnimalVm animal)
        {
            try
            {
                return Ok(await this.animalService.Insert(animal));
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Criar um animais, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para atualizar um animal
        /// </summary>
        /// <param name="id">Id do animal a ser atualizado</param>
        /// <param name="animal">Objeto para atualizar um animal</param>
        /// <returns>Retorna um objeto DataResult</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(Int64 id, [FromBody] AnimalVm animal)
        {
            try
            {
                animal.Id = id;
                return Ok(await this.animalService.Update(animal));
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Update de animais, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para Remover um animal
        /// </summary>
        /// <param name="id">Id do animal a ser removido</param>
        /// <returns>Retorna um objeto DataResult</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(Int64 id)
        {
            try
            {
                return Ok(await this.animalService.Delete(id));
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Metodo Delete de animais, mensagem {ex.Message}");
                return BadRequest(ex.Message);
            }
        }
    }
}
