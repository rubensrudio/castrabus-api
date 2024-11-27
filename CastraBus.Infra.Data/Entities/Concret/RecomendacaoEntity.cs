using CastraBus.Infra.Data.Entities.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CastraBus.Infra.Data.Entities.Concret
{
    [Table("Recomendacao")]
    public class RecomendacaoEntity : BaseEntity
    {
        [Column("pesoInicial")]
        public Double PesoInicio { get; set; }

        [Column("pesoFinal")]
        public Double PesoFim { get; set; }

        [Column("quantidadeComprimidos")]
        public Double QtdComprimidos { get; set; }

        [Column("dose")]
        [StringLength(20)]
        public String Dose { get; set; }

        [Column("dias")]
        public Int64 dias { get; set; }

        [Column("uso")]
        [StringLength(20)]
        public String Uso { get; set; }

        public MedicacaoEntity Medicacao { get; set; }

        [Column("medicacao_Id")]
        public Int64 MedicacaoId { get; set; }
    }
}
