using CastraBus.Application.Entities.Generic;
using CastraBus.Application.Entities.ViewModel;

namespace CastraBus.Application.Services.Concret
{
    public class RestricaoMedicamentoVm : BaseVm
    {
        public Int64 CampanhaId { get; set; }
        public Int64 MedicamentoId { get; set; }

        public CampanhaVm Campanha { get; set; }
        public MedicamentoVm Medicamento { get; set; }
    }
}
