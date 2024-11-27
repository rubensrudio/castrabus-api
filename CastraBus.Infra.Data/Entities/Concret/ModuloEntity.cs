using CastraBus.Infra.Data.Entities.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CastraBus.Infra.Data.Entities.Concret
{
    [Table("Modulo")]
    public class ModuloEntity : BaseEntity
    {
        [Column("nome")]
        [StringLength(40)]
        public String Nome { get; set; }

        public ICollection<PermissaoEntity> Permissoes { get; set; } = new HashSet<PermissaoEntity>();
    }
}
