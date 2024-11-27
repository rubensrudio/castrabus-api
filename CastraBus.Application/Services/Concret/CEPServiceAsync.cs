using Caelum.Stella.CSharp.Format;
using CastraBus.Application.Entities.ViewModel;
using ViaCep;

namespace CastraBus.Application.Services.Concret
{
    public class CEPServiceAsync
    {
        public async Task<EnderecoVm> GetLocalizaCep(string cep)
        {
			try
			{
                ViaCepClient viaCep = new ViaCepClient();
                return new EnderecoVm(await viaCep.SearchAsync(new CEPFormatter().Unformat(cep), CancellationToken.None));
            }
			catch (Exception ex)
			{
				throw ex;
			}
        }
    }
}
