using CastraBus.Application.Entities.Generic;
using CastraBus.Application.Services.Concret;

namespace CastraBus.Application.Entities.ViewModel
{
    public class CampanhaVm : BaseVm
    {
        public String nomecampanha { get; set; }
        public String localcampanha { get; set; }
        public Int64 estadoId { get; set; }
        public Int64 cidadeId { get; set; }
        public Int64 bairroId { get; set; }
        public String? estado { get; set; }
        public String? cidade { get; set; }
        public String? bairro { get; set; }
        public String dataInicio { get; set; }
        public String dataFim { get; set; }
        public String horaInicio { get; set; }
        public String horaFim { get; set; }
        public String horaInicioIntervalo { get; set; }
        public String horaFimIntervalo { get; set; }
        public Int64 intervaloAtendimento { get; set; }
        public Int64 pontuacaoDia { get; set; }
        public Int64? EmpresaId { get; set; }

        public DiasAtendimentoVm? diasAtendimento { get; set; }
        public RestricaoEspecieVm? restricaoEspecie { get; set; }
        public IEnumerable<FaixaHorarioVm>? faixaHorarios { get; set; }
        public IEnumerable<RestricaoMedicamentoVm>? restricaoMedicamentos { get; set; }
    }
}
