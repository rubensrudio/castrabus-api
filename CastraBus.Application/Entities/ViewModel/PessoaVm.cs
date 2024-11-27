using CastraBus.Application.Entities.Generic;
using CastraBus.Application.Validations;
using CastraBus.Infra.Data.Entities.Concret;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CastraBus.Application.Entities.ViewModel
{
    public class PessoaVm : BaseVm
    {
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        [StringLength(255)]
        [MaxLength(255, ErrorMessage = "Valor do campo é superior a 255 caracteres")]
        public required String NomeCompleto { get; set; }

        public required String DataNascimento { get; set; }

        [Required(ErrorMessage = "O campo CPF é obrigatório")]
        [StringLength(14)]
        [MaxLength(14, ErrorMessage = "Valor do campo é superior a 11 caracteres")]
        [CPFAttributeValidation(ErrorMessage = "CPF Inválido")]
        public required String CPF { get; set; }

        [Required(ErrorMessage = "O campo Identidade é obrigatório")]
        [StringLength(30)]
        [MaxLength(30, ErrorMessage = "Valor do campo é superior a 40 caracteres")]
        public required String Identidade { get; set; }

        [StringLength(30)]
        [MaxLength(30)]
        public required String Telefone { get; set; }

        [Required(ErrorMessage = "O campo Endereço é obrigatório")]
        [StringLength(4000)]
        [MaxLength(4000, ErrorMessage = "Valor do campo é superior a 4000 caracteres")]
        public required String Endereco { get; set; }

        public Int64 estadoId { get; set; }
        public Int64 cidadeId { get; set; }
        public Int64 bairroId { get; set; }

        public String? Bairro { get; set; }

        public String? Cidade { get; set; }

        public String? Estado { get; set; }

        [Required(ErrorMessage = "O campo CEP é obrigatório")]
        [StringLength(9)]
        [MaxLength(9, ErrorMessage = "Valor do campo é superior a 10 caracteres")]
        public required String CEP { get; set; }

        [EmailAddress]
        [MaxLength(100)]
        [StringLength(100)]
        public String? Email { get; set; }

        [StringLength(100)]
        public String? CRMV { get; set; }

        public Int64 SexoId { get; set; }

        public Int64 TipoPessoaId { get; set; }

        public Int64 UsuarioId { get; set; }

        [PasswordPropertyText]
        public String? Senha { get; set; }

        //public ICollection<AnimalVm>? Animals { get; set; } = new HashSet<AnimalVm>();
        public List<ArquivoVm>? Arquivos { get; set; } = [];
    }
}
