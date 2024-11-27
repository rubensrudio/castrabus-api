using CastraBus.Infra.Data.Entities.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CastraBus.Infra.Data.Entities.Concret
{
    [Table("Pessoa")]
    public class PessoaEntity : BaseEntity
    {
        [Column("nome_completo")]
        [StringLength(255)]
        public String NomeCompleto { get; set; }

        [Column("data_nascimento")]
        public String DataNascimento { get; set; }

        [Column("cpf")]
        [StringLength(14)]
        public String CPF { get; set; }

        [Column("identidade")]
        [StringLength(30)]
        public String Identidade { get; set; }

        [Column("telefone")]
        [StringLength(30)]
        public String Telefone { get; set; }

        [Column("endereco")]
        [StringLength(4000)]
        public String Endereco { get; set; }

        [Column("estadoId")]
        public Int64 estadoId { get; set; }

        [Column("cidadeId")]
        public Int64 cidadeId { get; set; }

        [Column("bairroId")]
        public Int64 bairroId { get; set; }

        [Column("cep")]
        [StringLength(9)]
        public String CEP { get; set; }

        [Column("email")]
        [StringLength(100)]
        public String? Email { get; set; }

        [Column("crmv")]
        [StringLength(100)]
        public String? CRMV { get; set; }

        public UsuarioEntity? Usuario { get; set; }

        [Column("usuario_id")]
        public Int64? UsuarioId { get; set; }

        public TipoSexoEntity Sexo { get; set; }

        [Column("sexo_id")]
        public Int64 SexoId { get; set; }

        public TipoPessoaEntity TipoPessoa { get; set; }

        [Column("tipo_pessoa_id")]
        public Int64 TipoPessoaId { get; set; }

        public ICollection<AnimalEntity>? Animals { get; set; } = new HashSet<AnimalEntity>();

        public ICollection<AgendamentoEntity>? Agendamentos { get; set; } = new HashSet<AgendamentoEntity>();

        public List<ArquivoEntity>? Arquivos { get; set; } = [];

        public AtendimentoEntity? AtendimentoVeterinario { get; set; }

        public ICollection<AtendimentoEntity>? AtendimentoTutor { get; set; } = new HashSet<AtendimentoEntity>();

        public ICollection<ReceitaEntity>? ReceitasTutor { get; set; } = new HashSet<ReceitaEntity>();

        public ICollection<ReceitaEntity>? ReceitasVeterinario { get; set; } = new HashSet<ReceitaEntity>();
    }
}
