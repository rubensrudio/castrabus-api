using CastraBus.Infra.Data.Entities.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CastraBus.Infra.Data.Entities.Concret
{
    [Table("Usuario")]
    public class UsuarioEntity : BaseEntity
    {
        [Column("username")]
        [StringLength(100)]
        public String Username { get; set; }

        [Column("email")]
        [StringLength(100)]
        public String Email { get; set; }

        [Column("password")]
        [StringLength(100)]
        public String Password { get; set; }

        public PerfilEntity Perfil { get; set; }

        [Column("perfil_id")]
        public Int64 PerfilId { get; set; }

        public EmpresaEntity Empresa { get; set; }
        
        [Column("empresa_id")]
        public Int64 EmpresaId { get; set; }

        public PessoaEntity? Pessoa { get; set; }

        [Column("pessoa_id")]
        public Int64? PessoaId { get; set; }

        public ICollection<ImportacaoArquivoEntity> ImportacaoArquivos { get; set; } = new HashSet<ImportacaoArquivoEntity>();
    }
}
