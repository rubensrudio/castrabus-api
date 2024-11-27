using CastraBus.Application.Entities.Generic;

namespace CastraBus.Application.Entities.ViewModel
{
    public class AgendaVm : BaseVm
    {
        public String Data { get; set; }
        public List<HorarioVm> Horarios { get; set; }
        public Boolean Disponivel { get; set; }
    }
}
