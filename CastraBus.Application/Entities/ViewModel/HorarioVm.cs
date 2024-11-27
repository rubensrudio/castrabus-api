using CastraBus.Application.Entities.Generic;

namespace CastraBus.Application.Entities.ViewModel
{
    public class HorarioVm : BaseVm
    {
        public String HoraInicio { get; set; }
        public String HoraFim { get; set; }
        public Boolean Disponivel { get; set; }
    }
}
