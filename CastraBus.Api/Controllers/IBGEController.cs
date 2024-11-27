using CastraBus.Application.Services.Concret;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CastraBus.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IBGEController : ControllerBase
    {
        private readonly IBGEServiceAsync iBGEServiceAsync;

        public IBGEController(IBGEServiceAsync iBGEServiceAsync)
        {
            this.iBGEServiceAsync = iBGEServiceAsync;
        }

        [HttpGet("GetEstados", Name = "GetEstados")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetEstados()
        {
            try
            {
                return Ok(await this.iBGEServiceAsync.GetEstados());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetCidadesByEstado/{estadoId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCidadesByEstado(Int64 estadoId)
        {
            try
            {
                return Ok(await this.iBGEServiceAsync.GetCidadesByEstado(estadoId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /*[HttpGet("GetDistritosByCidade/{cidadeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetDistritosByCidade(Int64 cidadeId)
        {
            try
            {
                return Ok(await this.iBGEServiceAsync.GetDistritosByCidade(cidadeId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }*/

        [HttpGet("GetBairrosByCidade/{cidadeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetBairrosByCidade(Int64 cidadeId)
        {
            try
            {
                return Ok(await this.iBGEServiceAsync.GetBairrosByCidade(cidadeId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetEstadoById/{estadoId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetEstadoById(Int64 estadoId)
        {
            try
            {
                return Ok(await this.iBGEServiceAsync.GetEstadoById(estadoId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetCidadeById/{cidadeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCidadeById(Int64 cidadeId)
        {
            try
            {
                return Ok(await this.iBGEServiceAsync.GetCidadeById(cidadeId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetBairroById/{bairroId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetBairroById(Int64 bairroId)
        {
            try
            {
                return Ok(await this.iBGEServiceAsync.GetBairroById(bairroId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
