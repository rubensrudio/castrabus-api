using CastraBus.Application.Entities.ViewModel;
using CastraBus.Application.Services.Concret;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CastraBus.Api.Controllers
{
    /// <summary>
    /// Classe Controller de Autenticação
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly TokenServiceAsync tokenService;
        private readonly GoogleAuthServiceAsync googleAuthService;
        private readonly FacebookAuthServiceAsync facebookAuthService;

        /// <summary>
        /// Construtor da controller Autenticação
        /// </summary>
        /// <param name="tokenService">Injeção de dependência do serviço de tokenService</param>
        /// <param name="googleAuthService">Injeção de dependência do serviço de GoogleAuthService</param>
        /// <param name="facebookAuthService">Injeção de dependência do serviço de FacebookAuthService</param>
        public AuthController(TokenServiceAsync tokenService
                            , GoogleAuthServiceAsync googleAuthService
                            , FacebookAuthServiceAsync facebookAuthService)
        {
            this.tokenService = tokenService;
            this.googleAuthService = googleAuthService;
            this.facebookAuthService = facebookAuthService;
        }

        /// <summary>
        /// Método para autenticar na aplicação via login e senha
        /// </summary>
        /// <param name="usuario">Objeto Usuario de acesso</param>
        /// <returns>Retorna token JWT</returns>
        [HttpPost("login", Name = "login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] UsuarioAcessoVm usuario)
        {
            var token = await this.tokenService.GenerateToken(usuario);

            if (token == null || token.IsNullOrEmpty())
            {
                return Unauthorized("Usuário não possui acesso no sistema");
            }

            return Ok(token);
        }

        /// <summary>
        /// Método para autenticar na aplicação via GOOGLE
        /// </summary>
        /// <param name="usuario">Payload Obtido via Google</param>
        /// <returns>Retorna token JWT</returns>
        [HttpPost("GoogleSignIn", Name = "GoogleSignIn")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GoogleSignIn(UsuarioGoogleVm usuario)
        {
            var token = await this.googleAuthService.GoogleSignIn(usuario);

            if (token == null || token.IsNullOrEmpty())
            {
                return Unauthorized("Usuário não possui acesso no sistema");
            }

            return Ok(token);
        }

        /// <summary>
        /// Método para autenticar na aplicação via FACEBOOK
        /// </summary>
        /// <param name="usuario">Payload Obtido via Facebook</param>
        /// <returns>Retorna token JWT</returns>
        [HttpPost("FacebookSignIn", Name = "FacebookSignIn")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> FacebookSignIn(UsuarioFacebookVm usuario)
        {
            var token = await this.facebookAuthService.FacebookSignIn(usuario);

            if (token == null || token.IsNullOrEmpty())
            {
                return Unauthorized("Usuário não possui acesso no sistema");
            }

            return Ok(token);
        }
    }
}
