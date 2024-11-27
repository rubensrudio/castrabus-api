using CastraBus.Application.Entities.Generic;

namespace CastraBus.Application.Entities.ViewModel
{
    public class VacinaVm : BaseVm
    {
        public String Nome { get; set; }
        public Int64? TipoVacinaId { get; set; }
        public String DataVacinacao { get; set; }
        public String DataProximaVacinacao { get; set; }
        public String Observacao { get; set; }
        public Int64 AnimalId { get; set; }
        public AnimalVm? Animal { get; set; }
        public TipoVacinaVm? TipoVacina { get; set; }
    }
}
