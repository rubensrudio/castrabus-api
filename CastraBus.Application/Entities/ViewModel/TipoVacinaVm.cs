using CastraBus.Application.Entities.Generic;
using System.ComponentModel.DataAnnotations;

namespace CastraBus.Application.Entities.ViewModel
{
    public class TipoVacinaVm : BaseVm
    {
        [StringLength(50)]
        public required String Nome { get; set; }
    }
}
