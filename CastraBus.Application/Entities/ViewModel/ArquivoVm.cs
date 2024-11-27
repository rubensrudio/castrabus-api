using CastraBus.Application.Entities.Generic;

namespace CastraBus.Application.Entities.ViewModel
{
    public class ArquivoVm : BaseVm
    {
        public List<PessoaVm>? Pessoas { get; set; } = [];
        public List<AnimalVm>? Animals { get; set; } = [];
    }
}
