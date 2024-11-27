using CastraBus.Infra.Data.Entities.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CastraBus.Infra.Data.Entities.Concret
{
    [Table("Empresa")]
    public class EmpresaEntity : BaseEntity
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

        public ICollection<UsuarioEntity> Usuarios { get; set; } = new HashSet<UsuarioEntity>();
        public ICollection<PerfilEntity> Perfils { get; set; } = new HashSet<PerfilEntity>();
        public ICollection<ImportacaoArquivoEntity> ImportacaoArquivos { get; set; } = new HashSet<ImportacaoArquivoEntity>();
        public ICollection<CampanhaEntity> Campanhas { get; set; } = new HashSet<CampanhaEntity>();
        public ICollection<AgendamentoEntity> Agendamentos { get; set; } = new HashSet<AgendamentoEntity>();
    }
}
