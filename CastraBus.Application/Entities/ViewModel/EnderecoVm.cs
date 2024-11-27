using CastraBus.Application.Entities.Generic;
using ViaCep;

namespace CastraBus.Application.Entities.ViewModel
{
    public class EnderecoVm : BaseVm
    {
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public string CEP { get; set; }

        public EnderecoVm() { }

        public EnderecoVm(ViaCepResult viaCep)
        {
            this.Estado = viaCep.StateInitials;
            this.Cidade = viaCep.City;
            this.Rua = viaCep.Street;
            this.Bairro = viaCep.Neighborhood;
            this.CEP = viaCep.ZipCode;
        }
    }
}
