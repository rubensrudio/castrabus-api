using CastraBus.Infra.Data.Entities.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CastraBus.Infra.Data.Entities.Concret
{
    [Table("TipoEmpresa")]
    public class TipoEmpresaEntity : BaseEntity
    {
        [Column("nome")]
        [StringLength(40)]
        public required String Nome{ get; set; }

        public ICollection<EmpresaEntity> Empresas { get; set; } = new HashSet<EmpresaEntity>();
        public ICollection<ContratanteEntity> Contratantes { get; set; } = new HashSet<ContratanteEntity>();
    }
}
