using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace PokeApiCore
{

    /// <summary>
    /// Client class to consume PokeApi
    /// https://pokeapi.co/
    /// Had to add Nuget pckg, System.net.http;
    /// MAKE ONLY ONE HTTPCLIENT
    /// </summary>
    public class PokeApiClient
    {
        static readonly HttpClient client = new HttpClient();

        /// <summary>
        /// Retrieve Pokemon by Name
        /// Catch isn't necessary but keeping it
        /// </summary>
        /// <exception cref="HttpRequestException"></exception>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<string> GetPokemonByName(string name)
        {
            try
            {
                string url = $"https://pokeapi.co/api/v2/pokemon/{name}";
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync(); //Puts it in a big string
                return responseBody;

            }
            catch(HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                throw ex;
            }
        }

        public void GetPokemonById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
