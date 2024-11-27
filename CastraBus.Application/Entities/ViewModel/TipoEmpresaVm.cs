using CastraBus.Application.Entities.Generic;
using System.ComponentModel.DataAnnotations;

namespace CastraBus.Application.Entities.ViewModel
{
    public class TipoEmpresaVm : BaseVm
    {
        [StringLength(40)]
        public required String Nome { get; set; }

        public ICollection<EmpresaVm> Empresas { get; set; } = new HashSet<EmpresaVm>();
    }
}
