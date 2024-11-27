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
    public class GoogleAuthServiceAsync
    {
        private readonly JwtOptions jwtOptions;
        private readonly GoogleOptions googleOptions;
        private readonly IConfiguration configuration;
        private readonly PerfilServiceAsync<PerfilVm, PerfilEntity> perfilService;
        private readonly UsuarioServiceAsync<UsuarioVm, UsuarioEntity> usuarioService;
        private readonly PermissaoServiceAsync<PermissaoVm, PermissaoEntity> permissaoService;

        public GoogleAuthServiceAsync(UsuarioServiceAsync<UsuarioVm, UsuarioEntity> usuarioService
                                     , PerfilServiceAsync<PerfilVm, PerfilEntity> perfilService
                                     , PermissaoServiceAsync<PermissaoVm, PermissaoEntity> permissaoService
                                     , IConfiguration configuration)
        {
            this.configuration = configuration;
            this.usuarioService = usuarioService;
            this.perfilService = perfilService;
            this.permissaoService = permissaoService;
            this.jwtOptions = this.configuration.GetSection("JwtOptions").Get<JwtOptions>();
            this.googleOptions = this.configuration.GetSection("GoogleOptions").Get<GoogleOptions>();
        }

        public async Task<string> GoogleSignIn(UsuarioGoogleVm usuario)
        {
            string key = string.Empty;
            string token = string.Empty;

            try
            {
                var user = await this.usuarioService.GetEmail(usuario.email);

                if (Equals(user, null))
                {
                    user = await CreateUserBase(usuario);
                }

                var perfil = await this.perfilService.GetOne(user.PerfilId);
                var permissions = await this.permissaoService.GetAllPermissionsByPerfil(perfil.Id);

                if (!string.IsNullOrEmpty(this.jwtOptions.SigningKey))
                {
                    key = this.jwtOptions.SigningKey;
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
                        new Claim("permissions", JsonSerializer.Serialize(permissions)),
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

        private async Task<UsuarioEntity> CreateUserBase(UsuarioGoogleVm usuario)
        {
            try
            {
                UsuarioVm user = new UsuarioVm()
                {
                    username = string.Concat(usuario.given_name, "_", usuario.family_name),
                    email = usuario.email,
                    password = CreatePassword(8),
                    PerfilId = 1,
                    EmpresaId = 1
                };

                await this.usuarioService.Insert(user);
                return await this.usuarioService.GetEmailAndPassword(usuario.email, user.password);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string CreatePassword(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }
    }
}
