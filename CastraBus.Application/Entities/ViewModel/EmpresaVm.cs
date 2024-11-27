using CastraBus.Application.Entities.Generic;
using CastraBus.Application.Validations;
using CastraBus.Infra.Data.Entities.Concret;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CastraBus.Application.Entities.ViewModel
{
    public class EmpresaVm : BaseVm
    {
        [StringLength(100)]
        public required String NomeFantasia { get; set; }

        [StringLength(20)]
        [CNPJAttributeValidation(ErrorMessage = "CNPJ Inválido")]
        public required String CNPJ { get; set; }

        [StringLength(200)]
        public String? RazaoSocial { get; set; }

        [StringLength(30)]
        public String? Telefone { get; set; }

        [StringLength(50)]
        public String? Responsavel { get; set; }

        [StringLength(100)]
        public String? Email { get; set; }

        public Int64 TipoEmpresaId { get; set; }
    }
}
