using CastraBus.Application.Entities.ViewModel;
using CastraBus.Common.Singleton;
using CastraBus.Common.Util;
using CastraBus.Infra.Data.Entities.Concret;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace CastraBus.Application.Services.Concret
{
    public class FacebookAuthServiceAsync
    {
        private readonly JwtOptions jwtOptions;
        private readonly HttpClient _httpClient;
        private readonly FacebookOptions facebookOptions;
        private readonly IConfiguration configuration;
        private readonly PerfilServiceAsync<PerfilVm, PerfilEntity> perfilService;
        private readonly UsuarioServiceAsync<UsuarioVm, UsuarioEntity> usuarioService;
        private readonly PermissaoServiceAsync<PermissaoVm, PermissaoEntity> permissaoService;

        public FacebookAuthServiceAsync(UsuarioServiceAsync<UsuarioVm, UsuarioEntity> usuarioService
                                      , PerfilServiceAsync<PerfilVm, PerfilEntity> perfilService
                                      , PermissaoServiceAsync<PermissaoVm, PermissaoEntity> permissaoService
                                      , IConfiguration configuration)
        {
            this.configuration = configuration;
            this.usuarioService = usuarioService;
            this.perfilService = perfilService;
            this.permissaoService = permissaoService;
            this.jwtOptions = this.configuration.GetSection("JwtOptions").Get<JwtOptions>();
            this.facebookOptions = this.configuration.GetSection("FacebookOptions").Get<FacebookOptions>();
        }

        public async Task<string> FacebookSignIn(UsuarioFacebookVm usuario)
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

        private async Task<UsuarioEntity> CreateUserBase(UsuarioFacebookVm usuario)
        {
            try
            {
                UsuarioVm user = new UsuarioVm()
                {
                    username = string.Concat(usuario.firstName, "_", usuario.lastName),
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

        /// <summary>
        /// Validates Facebook Accesstoken
        /// </summary>
        /// <param name="accessToken">the accesstoken from facebook</param>
        /// <returns>Task&lt;BaseResponse&lt;FacebookTokenValidationResponse&gt;&gt;</returns>
        public async Task<BaseResponse<FacebookTokenValidationResponse>> ValidateFacebookToken(string accessToken)
        {
            try
            {
                string TokenValidationUrl = facebookOptions.TokenValidationUrl;
                var url = string.Format(TokenValidationUrl, accessToken, facebookOptions.AppId, facebookOptions.AppSecret);
                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var responseAsString = await response.Content.ReadAsStringAsync();

                    var tokenValidationResponse = JsonSerializer.Deserialize<FacebookTokenValidationResponse>(responseAsString);
                    return new BaseResponse<FacebookTokenValidationResponse>(tokenValidationResponse);
                }
            }
            catch (Exception ex)
            {
                return new BaseResponse<FacebookTokenValidationResponse>(null, "Failed to get response");
            }

            return new BaseResponse<FacebookTokenValidationResponse>(null, "Failed to get response");
        }

        /// <summary>
        /// Get Facebook User Information.
        /// </summary>
        /// <param name="accessToken">the access token from facebook</param>
        /// <returns>Task&lt;BaseResponse&lt;FacebookUserInfoResponse&gt;&gt;</returns>
        public async Task<BaseResponse<FacebookUserInfoResponse>> GetFacebookUserInformation(string accessToken)
        {
            try
            {
                string userInfoUrl = facebookOptions.UserInfoUrl;
                string url = string.Format(userInfoUrl, accessToken);

                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var responseAsString = await response.Content.ReadAsStringAsync();
                    var userInfoResponse = JsonSerializer.Deserialize<FacebookUserInfoResponse>(responseAsString);
                    return new BaseResponse<FacebookUserInfoResponse>(userInfoResponse);
                }
            }
            catch (Exception ex)
            {
                return new BaseResponse<FacebookUserInfoResponse>(null, "Failed to get response");
            }

            return new BaseResponse<FacebookUserInfoResponse>(null, "Failed to get response");
        }
    }
}
