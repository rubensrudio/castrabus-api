using CastraBus.Infra.Data.Entities.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CastraBus.Infra.Data.Entities.Concret
{
    [Table("Contratante")]
    public class ContratanteEntity : BaseEntity
    {
        [Column("nome_fantasia")]
        [StringLength(100)]
        public required String NomeFantasia { get; set; }

        [Column("cnpj")]
        [StringLength(20)]
        public required String CNPJ { get; set; }

        [Column("razao_social")]
        [StringLength(200)]
        public String? RazaoSocial { get; set; }

        [Column("telefone")]
        [StringLength(30)]
        public String? Telefone { get; set; }

        [Column("responsavel")]
        [StringLength(50)]
        public String? Responsavel { get; set; }

        [Column("email")]
        [StringLength(100)]
        public String? Email { get; set; }

        [Column("tipoEmpresa_id")]
        public Int64 TipoEmpresaId { get; set; }

        public TipoEmpresaEntity TipoEmpresa { get; set; }
    }
}
