using CastraBus.Infra.Data.Entities.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CastraBus.Infra.Data.Entities.Concret
{
    [Table("Perfil")]
    public class PerfilEntity : BaseEntity
    {
        [Column("nome")]
        [StringLength(50)]
        public required String Nome { get; set; }

        [Column("role")]
        [StringLength(50)]
        public required String Role { get; set; }

        public EmpresaEntity Empresa { get; set; }

        [Column("empresa_id")]
        public Int64 EmpresaId { get; set; }

        public ICollection<UsuarioEntity> Usuarios { get; set; } = new HashSet<UsuarioEntity>();

        public ICollection<PermissaoEntity> Permissoes { get; set; } = new HashSet<PermissaoEntity>();
    }
}
