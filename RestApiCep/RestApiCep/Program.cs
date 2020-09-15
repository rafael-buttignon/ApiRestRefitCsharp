using Refit;
using System;
using System.Threading.Tasks;

namespace RestApiCep
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            try
            {
                var cepClient = RestService.For<ICepApiService>("https://viacep.com.br");
                Console.WriteLine("Informe seu cep: ");

                var cepInformado = Console.ReadLine().ToString();
                Console.WriteLine("Consultando informações do CEP: " + cepInformado);
                var address = await cepClient.GetAddressAsync(cepInformado);

                Console.WriteLine($"" +
                    $"\nLogradouro: {address.Logradouro}" +
                    $"\nBairro: {address.Bairro}" +
                    $"\nComplemento: {address.Complemento}" +
                    $"\nCidade: {address.Localidade}" +
                    $"\nUf: {address.Uf}");

                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro na consulta de cep: " + e.Message);
            }
        }
    }
}