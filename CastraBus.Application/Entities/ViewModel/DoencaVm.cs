using CastraBus.Application.Entities.Generic;

namespace CastraBus.Application.Entities.ViewModel
{
    public class DoencaVm : BaseVm
    {
        public String Nome { get; set; }
        public Int64? TipoDoencaId { get; set; }
        public String Diagnostico { get; set; }
        public String Tratamento { get; set; }
        public Int64 AnimalId { get; set; }
        public AnimalVm? Animal { get; set; }
        public TipoDoencaVm? TipoDoenca { get; set; }
    }
}
