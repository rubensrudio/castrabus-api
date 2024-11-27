using CastraBus.Infra.Data.Entities.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CastraBus.Infra.Data.Entities.Concret
{
    [Table("Agendamento")]
    public class AgendamentoEntity : BaseEntity
    {
        [Column("data")]
        [StringLength(20)]
        public String Data { get; set; }

        [Column("pessoa_id")]
        public Int64 PessoaId { get; set; }

        public PessoaEntity Pessoa { get; set; }

        [Column("hora")]
        [StringLength(20)]
        public String Hora { get; set; }

        [Column("animal_id")]
        public Int64 AnimalId { get; set; }

        public AnimalEntity Animal { get; set; }

        [Column("empresa_id")]
        public Int64 EmpresaId { get; set; }

        public EmpresaEntity Empresa { get; set; }

        [Column("campanha_id")]
        public Int64 CampanhaId { get; set; }

        public CampanhaEntity Campanha { get; set; }

        public AtendimentoEntity? Atendimento { get; set; }

        public ICollection<ReceitaEntity>? Receitas { get; set; } = new HashSet<ReceitaEntity>();
    }
}
