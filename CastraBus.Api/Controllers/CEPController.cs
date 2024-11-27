using CastraBus.Application.Services.Concret;
using Microsoft.AspNetCore.Mvc;

namespace CastraBus.Api.Controllers
{
    /// <summary>
    /// Classe Controller de CEP
    /// </summary>
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CEPController : ControllerBase
    {
        private readonly CEPServiceAsync cepServiceAsync;

        /// <summary>
        /// Construtor da controller CEP
        /// </summary>
        /// <param name="cepServiceAsync">Injeção de dependência do serviço de CEP</param>
        public CEPController(CEPServiceAsync cepServiceAsync)
        {
            this.cepServiceAsync = cepServiceAsync;
        }

        /// <summary>
        /// Método para obter a localização baseado no CEP
        /// </summary>
        /// <param name="cep">String do CEP do endereço</param>
        /// <returns>Retorna um objeto Endereço baseado no CEP</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(string cep)
        {
            try
            {
                return Ok(await this.cepServiceAsync.GetLocalizaCep(cep));
            }
            catch (Exception ex)
            {
                return  BadRequest(ex.Message);
            }
        }
    }
}
