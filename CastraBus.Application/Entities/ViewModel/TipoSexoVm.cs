using CastraBus.Application.Entities.Generic;
using System.ComponentModel.DataAnnotations;

namespace CastraBus.Application.Entities.ViewModel
{
    public class TipoSexoVm : BaseVm
    {
        [StringLength(50)]
        public String Nome { get; set; }
    }
}
