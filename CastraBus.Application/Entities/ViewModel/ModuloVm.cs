using CastraBus.Application.Entities.Generic;
using System.ComponentModel.DataAnnotations;

namespace CastraBus.Application.Entities.ViewModel
{
    public class ModuloVm : BaseVm
    {
        [StringLength(40)]
        public String Nome { get; set; }
    }
}
