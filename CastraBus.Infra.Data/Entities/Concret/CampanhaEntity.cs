using CastraBus.Infra.Data.Entities.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CastraBus.Infra.Data.Entities.Concret
{
    [Table("Campanha")]
    public class CampanhaEntity : BaseEntity
    {
        [Column("nomecampanha")]
        [StringLength(200)]
        public String NomeCampanha { get; set; }

        [Column("localcampanha")]
        [StringLength(200)]
        public String LocalCampanha { get; set; }

        [Column("estadoId")]
        public Int64 estadoId { get; set; }

        [Column("cidadeId")]
        public Int64 cidadeId { get; set; }

        [Column("bairroId")]
        public Int64 bairroId { get; set; }

        [Column("dataInicio")]
        [StringLength(20)]
        public String dataInicio { get; set; }

        [Column("dataFim")]
        [StringLength(20)]
        public String dataFim { get; set; }

        [Column("horaInicio")]
        [StringLength(20)]
        public String horaInicio { get; set; }

        [Column("horaFim")]
        [StringLength(20)]
        public String horaFim { get; set; }

        [Column("horaInicioIntervalo")]
        [StringLength(20)]
        public String horaInicioIntervalo { get; set; }

        [Column("horaFimIntervalo")]
        [StringLength(20)]
        public String horaFimIntervalo { get; set; }

        [Column("domingo")]
        public Boolean domingo { get; set; }

        [Column("segunda")]
        public Boolean segunda { get; set; }

        [Column("terca")]
        public Boolean terca { get; set; }

        [Column("quarta")]
        public Boolean quarta { get; set; }

        [Column("quinta")]
        public Boolean quinta { get; set; }

        [Column("sexta")]
        public Boolean sexta { get; set; }

        [Column("sabado")]
        public Boolean sabado { get; set; }

        [Column("pontuacaoDia")]
        public Int64 pontuacaoDia { get; set; }

        [Column("intervaloAtendimento")]
        public Int64 IntervaloAtendimento { get; set; }

        [Column("caninoManha")]
        public Boolean caninoManha { get; set; }

        [Column("caninoTarde")]
        public Boolean caninoTarde { get; set; }

        [Column("felinoManha")]
        public Boolean felinoManha { get; set; }

        [Column("felinoTarde")]
        public Boolean felinoTarde { get; set; }

        [Column("empresa_id")]
        public Int64 EmpresaId { get; set; }

        public EmpresaEntity Empresa { get; set; }

        public ICollection<FaixaHorarioEntity> FaixaHorarios { get; set; } = new HashSet<FaixaHorarioEntity>();
        public ICollection<AgendamentoEntity> Agendamentos { get; set; } = new HashSet<AgendamentoEntity>();
    }
}
