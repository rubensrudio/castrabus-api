using CastraBus.Infra.Data.Entities.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CastraBus.Infra.Data.Entities.Concret
{
    [Table("Permissoes")]
    public class PermissaoEntity : BaseEntity
    {
        [Column("inserir")]
        public Boolean Inserir { get; set; }

        [Column("editar")]
        public Boolean Editar { get; set; }

        [Column("excluir")]
        public Boolean Excluir { get; set; }

        [Column("visualizar")]
        public Boolean Visualizar { get; set; }

        public PerfilEntity Perfil { get; set; }

        [Column("perfil_id")]
        public Int64 PerfilId { get; set; }

        public ModuloEntity Modulo { get; set; }

        [Column("modulo_id")]
        public Int64 ModuloId { get; set; }
    }
}
