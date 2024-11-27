using CastraBus.Infra.Data.Entities.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CastraBus.Infra.Data.Entities.Concret
{
    [Table("TipoVacina")]
    public class TipoVacinaEntity : BaseEntity
    {
        [Column("nome")]
        [StringLength(50)]
        public required String Nome { get; set; }

        public ICollection<VacinaEntity> Vacinas { get; set; } = new HashSet<VacinaEntity>();
    }
}
