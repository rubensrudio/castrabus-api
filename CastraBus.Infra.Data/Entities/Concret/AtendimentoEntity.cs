using CastraBus.Common.Domain.Concret.Enuns;
using CastraBus.Infra.Data.Entities.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CastraBus.Infra.Data.Entities.Concret
{
    [Table("Atendimento")]
    public class AtendimentoEntity : BaseEntity
    {
        [Column("tipoCirurgia")]
        [StringLength(4000)]
        public String? TipoCirurgia { get; set; }

        [Column("receita_Id")]
        public Int64? Receita_Id { get; set; }

        [Column("senhaAtendimento")]
        [StringLength(100)]
        public String SenhaAtendimento { get; set; }

        [Column("dataAtendimento")]
        public String DataAtendimento { get; set; }

        [Column("statusAtendimento")]
        public StatusAtendimentoEnum StatusAtendimento { get; set; }

        [Column("agendamento_Id")]
        public Int64 Agendamento_Id { get; set; }

        [Column("animal_Id")]
        public Int64 Animal_Id { get; set; }

        [Column("tutor_Id")]
        public Int64 Tutor_Id { get; set; }

        [Column("veterinario_Id")]
        public Int64? Veterinario_Id { get; set; }

        [Column("antiCio")]
        public Boolean AntiCio { get; set; }

        [Column("cioRecente")]
        public Boolean CioRecente { get; set; }

        [Column("criseEpileptica")]
        public Boolean CriseEpileptica { get; set; }

        [Column("desmaios")]
        public Boolean Desmaios { get; set; }

        [Column("filhoteRecente")]
        public Boolean FilhoteRecente { get; set; }

        [Column("historicoDoencas")]
        public Boolean HistoricoDoencas { get; set; }

        [Column("historicoVeterinario")]
        public Boolean HistoricoVeterinario { get; set; }

        [Column("horarioPreso")]
        public String? HorarioPreso { get; set; }

        [Column("idadeFilhote")]
        public Int64? IdadeFilhote { get; set; }

        [Column("jejum")]
        public Boolean Jejum { get; set; }

        [Column("observacoesComportamento")]
        public String? ObservacoesComportamento { get; set; }

        [Column("presoDuranteNoite")]
        public Boolean PresoDuranteNoite { get; set; }

        [Column("quandoCruzou")]
        public String? QuandoCruzou { get; set; }

        [Column("quandoTratamentoCirurgico")]
        public String? QuandoTratamentoCirurgico { get; set; }

        [Column("soltoDuranteNoite")]
        public Boolean SoltoDuranteNoite { get; set; }

        [Column("tratamentoCirurgico")]
        public Boolean TratamentoCirurgico { get; set; }

        [Column("ultimaAlimentacao")]
        public String? UltimaAlimentacao { get; set; }

        [Column("ultimaAplicacao")]
        public String? UltimaAplicacao { get; set; }

        [Column("ultimaIngestaoLiquidos")]
        public String? UltimaIngestaoLiquidos { get; set; }

        [Column("urinandoNormalmente")]
        public Boolean UrinandoNormalmente { get; set; }

        [Column("vermifugado")]
        public Boolean Vermifugado { get; set; }

        [Column("esterilizacao")]
        public Boolean? Esterilizacao { get; set; }

        [Column("motivo_esterilizacao")]
        [StringLength(4000)]
        public String? MotivoEsterilizacao { get; set; }

        [Column("intercorrencia")]
        public Boolean? Intercorrencia { get; set; }

        [Column("motivo_intercorrencia")]
        [StringLength(4000)]
        public String? MotivoIntercorrencia { get; set; }

        public AnimalEntity Animal { get; set; }

        public PessoaEntity Tutor { get; set; }

        public AgendamentoEntity Agendamento { get; set; }

        public ReceitaEntity? Receita { get; set; }
    }
}
