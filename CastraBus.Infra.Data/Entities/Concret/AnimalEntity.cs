using CastraBus.Infra.Data.Entities.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CastraBus.Infra.Data.Entities.Concret
{
    [Table("Animal")]
    public class AnimalEntity : BaseEntity
    {
        [Column("nome")]
        [StringLength(50)]
        public required String Nome { get; set; }

        [Column("ano")]
        public string? Ano { get; set; }

        [Column("meses")]
        public string? Meses { get; set; }

        [Column("peso")]
        public Double Peso { get; set; }

        [Column("chip")]
        [StringLength(50)]
        public String? Chip { get; set; }

        [Column("raca")]
        [StringLength(50)]
        public String? Raca { get; set; }

        [Column("pelagem")]
        [StringLength(50)]
        public String? Pelagem { get; set; }

        public TipoSexoEntity Sexo { get; set; }

        [Column("sexo_id")]
        public Int64 SexoId { get; set; }

        public TipoEspecieEntity Especie { get; set; }

        [Column("especie_id")]
        public Int64 EspecieId { get; set; }

        public PessoaEntity Pessoa { get; set; }

        [Column("pessoa_id")]
        public Int64 PessoaId { get; set; }

        public ICollection<VacinaEntity> Vacinas { get; set; } = new HashSet<VacinaEntity>();

        public ICollection<DoencaEntity> Doencas { get; set; } = new HashSet<DoencaEntity>();

        public List<ArquivoEntity>? Arquivos { get; set; } = [];

        public List<AgendamentoEntity>? Agendamentos { get; set; } = [];

        public ICollection<AtendimentoEntity>? Atendimentos { get; set; } = new HashSet<AtendimentoEntity>();

        public ICollection<ReceitaEntity>? Receitas { get; set; } = new HashSet<ReceitaEntity>();
    }
}
