using CastraBus.Application.Entities.Generic;

namespace CastraBus.Application.Entities.ViewModel
{
    public class FaixaHorarioVm : BaseVm
    {
        public String HorarioInicio { get; set; }
        public String HorarioFim { get; set; }
        public Int64 TipoEspecieId { get; set; }
        public Int64 CampanhaId { get; set; }

        public CampanhaVm Campanha { get; set; }
        public TipoEspecieVm TipoEspecie { get; set; }
    }
}
