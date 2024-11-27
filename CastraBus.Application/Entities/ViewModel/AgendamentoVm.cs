using CastraBus.Application.Entities.Generic;
using CastraBus.Common.Domain.Concret.Enuns;

namespace CastraBus.Application.Entities.ViewModel
{
    public class AgendamentoVm : BaseVm
    {
        public String Data { get; set; }

        public String Hora { get; set; }

        public Int64 PessoaId { get; set; }

        public PessoaVm? Pessoa { get; set; }

        public Int64 AnimalId { get; set; }

        public AnimalVm? Animal { get; set; }

        public Int64 EmpresaId { get; set; }

        public String? SenhaAtendimento { get; set; }

        public StatusAtendimentoEnum? StatusAtendimento { get; set; }

        public EmpresaVm? Empresa { get; set; }

        public Int64 CampanhaId { get; set; }

        public CampanhaVm? Campanha { get; set; }
    }
}
