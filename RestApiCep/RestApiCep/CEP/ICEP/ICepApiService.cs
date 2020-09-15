using Refit;
using System.Threading.Tasks;

namespace RestApiCep
{
    public interface ICepApiService
    {
        [Get("/ws/{cep}/json/")]
        Task<CepResponse> GetAddressAsync(string cep);
    }
}