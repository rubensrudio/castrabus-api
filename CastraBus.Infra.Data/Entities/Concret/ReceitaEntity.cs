using CastraBus.Infra.Data.Entities.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CastraBus.Infra.Data.Entities.Concret
{
    [Table("Receita")]
    public class ReceitaEntity : BaseEntity
    {
        [Column("agendamento_Id")]
        public Int64 Agendamento_Id { get; set; }

        [Column("atendimento_Id")]
        public Int64 Atendimento_Id { get; set; }

        [Column("animal_Id")]
        public Int64 Animal_Id { get; set; }

        [Column("veterinario_Id")]
        public Int64 Veterinario_Id { get; set; }

        [Column("tutor_Id")]
        public Int64 Tutor_Id { get; set; }

        public PessoaEntity Tutor { get; set; }
        public AnimalEntity Animal { get; set; }
        public PessoaEntity Veterinario { get; set; }
        public AgendamentoEntity Agendamento { get; set; }
        public AtendimentoEntity Atendimento { get; set; }
        public ICollection<MedicacaoEntity> Medicacoes { get; set; } = new List<MedicacaoEntity>();
    }
}
