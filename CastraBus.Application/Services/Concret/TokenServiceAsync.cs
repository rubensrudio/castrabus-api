using CastraBus.Application.Entities.ViewModel;
using CastraBus.Common.Singleton;
using CastraBus.Infra.Data.Entities.Concret;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace CastraBus.Application.Services.Concret
{
    public class TokenServiceAsync
    {
        private readonly JwtOptions jwtOptions;
        private readonly IConfiguration configuration;
        private readonly FacebookAuthServiceAsync facebookAuthServiceAsync;
        private readonly PerfilServiceAsync<PerfilVm, PerfilEntity> perfilService;
        private readonly UsuarioServiceAsync<UsuarioVm, UsuarioEntity> usuarioService;
        private readonly PermissaoServiceAsync<PermissaoVm, PermissaoEntity> permissaoService;

        public TokenServiceAsync(UsuarioServiceAsync<UsuarioVm, UsuarioEntity> usuarioService
                                , PerfilServiceAsync<PerfilVm, PerfilEntity> perfilService
                                , PermissaoServiceAsync<PermissaoVm, PermissaoEntity> permissaoService
                                , IConfiguration configuration)
        {
            this.usuarioService = usuarioService;
            this.configuration = configuration;
            this.perfilService = perfilService;
            this.permissaoService = permissaoService;
            this.jwtOptions = this.configuration.GetSection("JwtOptions").Get<JwtOptions>();
        }

        public async Task<string> GenerateToken(UsuarioAcessoVm usuarioAcesso)
        {
            string key = string.Empty;
            string token = string.Empty;
            string jsonPermissions = string.Empty;

            try
			{
                var user = await this.usuarioService.GetEmailAndPassword(usuarioAcesso.email, usuarioAcesso.password);

                if (Equals(user, null))
                {
                    return token;
                }

                var perfil = await this.perfilService.GetOne(user.PerfilId);
                var permissions = await this.permissaoService.GetAllPermissionsByPerfil(perfil.Id);

                if (!string.IsNullOrEmpty(this.jwtOptions.SigningKey))
                {
                    key = this.jwtOptions.SigningKey;
                }

                if (!Equals(permissions, null))
                {
                    jsonPermissions = JsonSerializer.Serialize(permissions);
                }

                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
                var issuer = this.jwtOptions.Issuer;
                var audience = this.jwtOptions.Audience;
                var expirationSeconds = this.jwtOptions.ExpirationSeconds;
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokenOptions = new JwtSecurityToken(
                    issuer: issuer,
                    audience: audience,
                    claims: new[]
                    {
                        new Claim("name", user.Username),
                        new Claim("role", perfil.Role),
                        new Claim("id", user.PessoaId.ToString()),
                        new Claim("empresa", user.EmpresaId.ToString()),
                        new Claim("permissions", jsonPermissions),
                    },
                    expires: DateTime.Now.AddSeconds(expirationSeconds),
                    signingCredentials: signinCredentials
                );

                token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

                return token;
			}
			catch (Exception ex)
			{
				throw ex;
			}
        }
    }
}
