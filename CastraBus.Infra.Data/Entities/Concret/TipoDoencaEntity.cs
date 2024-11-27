using CastraBus.Infra.Data.Entities.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CastraBus.Infra.Data.Entities.Concret
{
    [Table("TipoDoenca")]
    public class TipoDoencaEntity : BaseEntity
    {
        [Column("nome")]
        [StringLength(50)]
        public required String Nome { get; set; }

        public ICollection<DoencaEntity> Doencas { get; set; } = new HashSet<DoencaEntity>();
    }
}
