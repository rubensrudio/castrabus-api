using CastraBus.Application.Entities.Generic;

namespace CastraBus.Application.Entities.ViewModel
{
    public class PermissaoVm : BaseVm
    {
        public Int64 moduloId { get; set; }

        public ModuloVm? modulo {  get; set; }

        public String? nome { get; set; }

        public Boolean Inserir { get; set; }

        public Boolean editar { get; set; }

        public Boolean excluir { get; set; }

        public Boolean visualizar { get; set; }

        public Int64 PerfilId { get; set; }
    }
}
