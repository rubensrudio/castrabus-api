using CastraBus.Application.Entities.Generic;

namespace CastraBus.Application.Entities.ViewModel
{
    public class AgendaCampanhaVm : BaseVm
    {
        public Int64 CampanhaId { get; set; }
        public List<AgendaVm> Agendas { get; set; }
    }
}
