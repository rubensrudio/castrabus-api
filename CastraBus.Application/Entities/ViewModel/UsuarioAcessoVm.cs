using System.ComponentModel.DataAnnotations;

namespace CastraBus.Application.Entities.ViewModel
{
    public class UsuarioAcessoVm
    {
        [Required(ErrorMessage = "E-mail é obrigatorio")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string email { get; set; }

        [Required(ErrorMessage = "Senha é obrigatoria")]
        [DataType(DataType.Password)]   
        public string password { get; set; }
    }
}
