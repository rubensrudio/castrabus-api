using CastraBus.Application.Entities.Generic;
using CastraBus.Common.Domain.Concret.Enuns;
using CastraBus.Infra.Data.Entities.Concret;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CastraBus.Application.Entities.ViewModel
{
    public class AtendimentoVm : BaseVm
    {
        public String TipoCirurgia { get; set; }
        public ReceitaVm? Receita { get; set; }
        public String SenhaAtendimento { get; set; }
        public StatusAtendimentoEnum StatusAtendimento { get; set; }
        public Int64 Agendamento_Id { get; set; }
        public Int64 Veterinario_Id { get; set; }
        public Int64 Tutor_Id { get; set; }
        public Int64 Animal_Id { get; set; }
        public Int64? Receita_Id { get; set; }
        public String? DataAtendimento { get; set; }
        public Boolean AntiCio { get; set; }
        public Boolean CioRecente { get; set; }
        public Boolean CriseEpileptica { get; set; }
        public Boolean Desmaios { get; set; }
        public Boolean FilhoteRecente { get; set; }
        public Boolean HistoricoDoencas { get; set; }
        public Boolean HistoricoVeterinario { get; set; }
        public String? HorarioPreso { get; set; }
        public Int64? IdadeFilhote { get; set; }
        public Boolean Jejum { get; set; }
        public String? ObservacoesComportamento { get; set; }
        public Boolean PresoDuranteNoite { get; set; }
        public String? QuandoCruzou { get; set; }
        public String? QuandoTratamentoCirurgico { get; set; }
        public Boolean SoltoDuranteNoite { get; set; }
        public Boolean TratamentoCirurgico { get; set; }
        public String? UltimaAlimentacao { get; set; }
        public String? UltimaAplicacao { get; set; }
        public String? UltimaIngestaoLiquidos { get; set; }
        public Boolean UrinandoNormalmente { get; set; }
        public Boolean Vermifugado { get; set; }
        public Boolean? Esterilizacao { get; set; }
        public String? MotivoEsterilizacao { get; set; }
        public Boolean? Intercorrencia { get; set; }
        public String? MotivoIntercorrencia { get; set; }
        public AgendamentoVm? Agendamento { get; set; }
        public PessoaVm? Veterinario { get; set; }
        public PessoaVm? Tutor { get; set; }
        public AnimalVm? Animal { get; set; }
    }
}
