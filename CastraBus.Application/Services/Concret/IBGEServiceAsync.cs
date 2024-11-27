using CastraBus.Application.Entities.ViewModel;
using CastraBus.Common.Singleton;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Text.Json;

namespace CastraBus.Application.Services.Concret
{
    public class IBGEServiceAsync
    {
        private readonly HttpClient httpClient;
        private readonly IbgeOptions ibgeOptions;
        private readonly IConfiguration configuration;

        public IBGEServiceAsync(IConfiguration configuration)
        {
            this.httpClient = new HttpClient();
            this.configuration = configuration;
            this.ibgeOptions = this.configuration.GetSection("IbgeOptions").Get<IbgeOptions>();
        }

        public async Task<IEnumerable<EstadoVm>> GetEstados()
        {
            try
            {
                String url = string.Concat(this.ibgeOptions.Url, this.ibgeOptions.UrlEstado);
                var response = await this.httpClient.GetAsync(url);
                var result = JsonSerializer.Deserialize<IEnumerable<EstadoVm>>(await response.Content.ReadAsStringAsync());
                return result.OrderBy(c => c.sigla);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<CidadeVm>> GetCidadesByEstado(Int64 Id)
        {
            try
            {
                String url = string.Concat(this.ibgeOptions.Url, this.ibgeOptions.UrlCidade.Replace("{uf}", Id.ToString()));
                var response = await this.httpClient.GetAsync(url);
                var result = JsonSerializer.Deserialize<IEnumerable<CidadeVm>>(await response.Content.ReadAsStringAsync());
                return result.OrderBy(c => c.nome);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<BairroVm>> GetBairrosByCidade(Int64 Id)
        {
            try
            {
                String url = string.Concat(this.ibgeOptions.Url, this.ibgeOptions.UrlBairro.Replace("{municipios}", Id.ToString()));
                var response = await this.httpClient.GetAsync(url);
                var retorno = JsonSerializer.Deserialize<IEnumerable<BairroVm>>(await response.Content.ReadAsStringAsync());
                if (Equals(retorno, null) || retorno.Count() == 0)
                {
                    url = string.Concat(this.ibgeOptions.Url, this.ibgeOptions.UrlDistrito.Replace("{municipios}", Id.ToString()));
                    response = await this.httpClient.GetAsync(url);
                    retorno = JsonSerializer.Deserialize<IEnumerable<BairroVm>>(await response.Content.ReadAsStringAsync());
                }
                return retorno.OrderBy(c => c.nome);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<EstadoVm> GetEstadoById(Int64 Id)
        {
            try
            {
                String url = string.Concat(this.ibgeOptions.Url, this.ibgeOptions.UrlEstadoById.Replace("{UF}", Id.ToString()));
                var response = await this.httpClient.GetAsync(url);
                var result = await response.Content.ReadAsStringAsync();

                if (Equals(result, "[]"))
                {
                    return null;
                }

                return JsonSerializer.Deserialize<EstadoVm>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CidadeVm> GetCidadeById(Int64 Id)
        {
            try
            {
                String url = string.Concat(this.ibgeOptions.Url, this.ibgeOptions.UrlCidadeById.Replace("{municipio}", Id.ToString()));
                var response = await this.httpClient.GetAsync(url);
                var result = await response.Content.ReadAsStringAsync();

                if (Equals(result, "[]"))
                {
                    return null;
                }

                return JsonSerializer.Deserialize<CidadeVm>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BairroVm> GetBairroById(Int64 Id)
        {
            try
            {
                String url = string.Concat(this.ibgeOptions.Url, this.ibgeOptions.UrlBairroById.Replace("{id}", Id.ToString()));
                var response = await this.httpClient.GetAsync(url);

                if (Equals(response.StatusCode, HttpStatusCode.InternalServerError))
                {
                    return null;
                }

                var retorno = JsonSerializer.Deserialize<IEnumerable<BairroVm>>(await response.Content.ReadAsStringAsync());
                
                if (Equals(retorno, null) || retorno.Count() == 0)
                {
                    url = string.Concat(this.ibgeOptions.Url, this.ibgeOptions.UrlDistritoById.Replace("{id}", Id.ToString()));
                    response = await this.httpClient.GetAsync(url);
                    retorno = JsonSerializer.Deserialize<IEnumerable<BairroVm>>(await response.Content.ReadAsStringAsync());
                }

                return retorno.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
