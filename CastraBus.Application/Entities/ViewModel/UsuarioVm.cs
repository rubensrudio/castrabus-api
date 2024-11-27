using CastraBus.Application.Entities.Generic;
using CastraBus.Infra.Data.Entities.Concret;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CastraBus.Application.Entities.ViewModel
{
    public class UsuarioVm : BaseVm
    {
        [Required(ErrorMessage = "Usuario é obrigatorio")]
        public string username { get; set; }

        [EmailAddress(ErrorMessage = "Email é obrigatorio")]
        public string email { get; set; }

        [Required(ErrorMessage = "Senha é obrigatoria")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        public Int64? PerfilId { get; set; }

        public Int64? EmpresaId { get; set; }

        public Int64? PessoaId { get; set; }
    }
}
