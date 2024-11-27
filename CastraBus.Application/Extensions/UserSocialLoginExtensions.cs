using CastraBus.Application.Entities.ViewModel;
using CastraBus.Application.Services.Concret;
using CastraBus.Common.Domain.Concret.Enuns;
using CastraBus.Infra.Data.Entities.Concret;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Extensions;

namespace CastraBus.Application.Extensions
{
    public static class UserSocialLoginExtensions
    {
        public static async Task<UsuarioVm> UserSocialLogin(this UserManager<UsuarioVm> userManager
                                               , UsuarioServiceAsync<UsuarioVm, UsuarioEntity> usuarioService
                                               , UserSocialLoginVm model
                                               , LoginProviderEnum loginProvider)
        {
            try
            {
                UsuarioVm usuario = null;
                var user = await userManager.FindByLoginAsync(loginProvider.GetDisplayName(), model.LoginProviderSubject);

                if (!Equals(user, null))
                    return user;

                var userLogin = await usuarioService.GetEmail(model.Email);

                if (Equals(userLogin, null))
                {
                    usuario = new UsuarioVm()
                    {
                        username = string.Concat(model.FirstName, model.LastName),
                        email = model.Email,
                        EmpresaId = 1,
                        PerfilId = 1
                    };

                    await usuarioService.Insert(usuario);
                }

                UserLoginInfo login = null;

                switch (loginProvider)
                {
                    case LoginProviderEnum.Google:
                        {
                            login = new UserLoginInfo(loginProvider.GetDisplayName(), model.LoginProviderSubject, loginProvider.GetDisplayName().ToUpper());
                        }
                        break;
                    
                    case LoginProviderEnum.Facebook:
                        {
                            login = new UserLoginInfo(loginProvider.GetDisplayName(), model.LoginProviderSubject, loginProvider.GetDisplayName().ToUpper());
                        }
                        break;

                    default:
                        break;
                }

                var result = await userManager.AddLoginAsync(usuario, login);

                if (result.Succeeded)
                {
                    return user;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
