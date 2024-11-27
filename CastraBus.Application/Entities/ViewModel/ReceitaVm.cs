using CastraBus.Application.Entities.Generic;

namespace CastraBus.Application.Entities.ViewModel
{
    public class ReceitaVm : BaseVm
    {
        public Int64 Agendamento_Id { get; set; }
        public Int64 Atendimento_Id { get; set; }
        public Int64 Animal_Id { get; set; }
        public Int64 Veterinario_Id { get; set; }
        public Int64 Tutor_Id { get; set; }

        public PessoaVm? Tutor { get; set; }
        public AnimalVm? Animal { get; set; }
        public PessoaVm? Veterinario { get; set; }
        public AgendamentoVm? Agendamento { get; set; }
        public AtendimentoVm? Atendimento { get; set; }
        public ICollection<MedicamentoVm>? Medicacoes { get; set; }
    }
}
