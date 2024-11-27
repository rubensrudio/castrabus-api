using CastraBus.Infra.Data.Entities.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CastraBus.Infra.Data.Entities.Concret
{
    [Table("Medicacao")]
    public class MedicacaoEntity : BaseEntity
    {
        [Column("nome")]
        [StringLength(100)]
        public String Nome { get; set; }

        [Column("dosagem")]
        public Int64 Dosagem { get; set; }

        [Column("unidadeMedida")]
        [StringLength(20)]
        public String UnidadeMedida { get; set; }

        [Column("capsulaComprimido")]
        [StringLength(20)]
        public String CapsulaComprimido { get; set; }

        [Column("tipoEspecie_Id")]
        public Int64 TipoEspecie_Id { get; set; }


        public TipoEspecieEntity TipoEspecie { get; set; }

        public ICollection<RecomendacaoEntity> Recomendacoes { get; set; } = new HashSet<RecomendacaoEntity>();

        public ICollection<ReceitaEntity> Receitas { get; set; } = new HashSet<ReceitaEntity>();
    }
}
