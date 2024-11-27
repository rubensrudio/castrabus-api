using CastraBus.Infra.Data.Entities.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CastraBus.Infra.Data.Entities.Concret
{
    [Table("TipoSexo")]
    public class TipoSexoEntity : BaseEntity
    {
        [Column("nome")]
        [StringLength(50)]
        public required String Nome { get; set; }

        public ICollection<AnimalEntity> Animals { get; set; } = new HashSet<AnimalEntity>();
        public ICollection<PessoaEntity> Pessoas { get; set; } = new HashSet<PessoaEntity>();
    }
}
