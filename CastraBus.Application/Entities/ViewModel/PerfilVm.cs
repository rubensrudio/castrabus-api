using CastraBus.Application.Entities.Generic;
using System.ComponentModel.DataAnnotations;

namespace CastraBus.Application.Entities.ViewModel
{
    public class PerfilVm : BaseVm
    {
        [StringLength(50)]
        public required String Nome { get; set; }

        public Int64 EmpresaId { get; set; }

        public String Role { get; set; }

        public ICollection<UsuarioVm>? Usuarios { get; set; } = new HashSet<UsuarioVm>();

        public ICollection<PermissaoVm>? Permissoes { get; set; } = new HashSet<PermissaoVm>();
    }
}
