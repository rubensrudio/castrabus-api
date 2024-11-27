using CastraBus.Application.Entities.Generic;
namespace CastraBus.Application.Entities.ViewModel
{
    public class MedicamentoVm : BaseVm
    {
        public String Nome { get; set; }
        public Int64 Dosagem { get; set; }
        public String UnidadeMedida { get; set; }
        public String CapsulaComprimido { get; set; }
        public Int64 TipoEspecie_Id { get; set; }

        public IList<RecomendacaoVm>? Recomendacoes { get; set; }
    }
}
