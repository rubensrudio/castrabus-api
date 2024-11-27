using CastraBus.Infra.Data.Entities.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CastraBus.Infra.Data.Entities.Concret
{
    [Table("ImportacaoArquivo")]
    public class ImportacaoArquivoEntity : BaseEntity
    {
        [Column("nome")]
        [StringLength(100)]
        public String Nome { get; set; }

        [Column("data_criacao")]
        [StringLength(100)]
        public String DataCriacao { get; set; }

        public UsuarioEntity Usuario { get; set; }

        [Column("usuario_id")]
        public Int64 UsuarioId { get; set; }

        [Column("extensao")]
        [StringLength(100)]
        public String Extensao { get; set; }

        [Column("tipo_integracao")]
        [StringLength(20)]
        public String TipoIntegracao { get; set; }

        [Column("empresa_id")]
        public Int64 EmpresaId { get; set; }

        public EmpresaEntity Empresa { get; set; }
    }
}
