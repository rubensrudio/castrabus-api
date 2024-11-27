using CastraBus.Application.Entities.Generic;

namespace CastraBus.Application.Entities.ViewModel
{
    public class PreOperatorioVm : BaseVm
    {
        public Int64 Agendamento_Id { get; set; }
        public Int64 Atendimento_Id { get; set; }
        public Int64 Animal_Id { get; set; }
        public Int64 Veterinario_Id { get; set; }
        public Int64 Tutor_Id { get; set; }

        public Boolean Jejum { get; set; }
        public String? UltimaAlimentacao { get; set; }
        public String? UltimaIngestaoLiquidos { get; set; }
        public Boolean PresoDuranteNoite { get; set; }
        public Boolean SoltoDuranteNoite { get; set; }
        public String? HorarioPreso { get; set; }
        public Boolean UrinandoNormalmente { get; set; }
        public Boolean AntiCio { get; set; }
        public String? UltimaAplicacao { get; set; }
        public Boolean CioRecente { get; set; }
        public String? QuandoCruzou { get; set; }
        public Boolean FilhoteRecente { get; set; }
        public Int64? IdadeFilhote { get; set; }
        public Boolean HistoricoVeterinario { get; set; }
        public Boolean TratamentoCirurgico { get; set; }
        public String? QuandoTratamentoCirurgico { get; set; }
        public String? ObservacoesComportamento { get; set; }
        public Boolean HistoricoDoencas { get; set; }
        public Boolean CriseEpileptica { get; set; }
        public Boolean Desmaios { get; set; }
        public Boolean Vermifugado { get; set; }
    }
}
