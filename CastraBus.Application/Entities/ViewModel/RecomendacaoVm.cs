using CastraBus.Application.Entities.Generic;

namespace CastraBus.Application.Entities.ViewModel
{
    public class RecomendacaoVm : BaseVm
    {
        public Double PesoInicio { get; set; }
        public Double PesoFim { get; set; }
        public Double QtdComprimidos { get; set; }
        public String Dose { get; set; }
        public Int64 dias { get; set; }
        public String Uso { get; set; }
        public Int64? MedicacaoId { get; set; }
    }
}
