using CastraBus.Application.Entities.Generic;

namespace CastraBus.Application.Entities.ViewModel
{
    public class TransOperatorioVm : BaseVm
    {
        public Int64 Agendamento_Id { get; set; }
        public Int64 Atendimento_Id { get; set; }
        public Int64 Animal_Id { get; set; }
        public Int64 Veterinario_Id { get; set; }
        public Int64 Tutor_Id { get; set; }

        public Boolean? Esterilizacao { get; set; }
        public String? MotivoEsterilizacao { get; set; }
        public Boolean? Intercorrencia { get; set; }
        public String? MotivoIntercorrencia { get; set; }
    }
}
