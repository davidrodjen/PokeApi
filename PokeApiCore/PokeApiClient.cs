using Newtonsoft.Json;
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
        /// <exception cref="ArgumentException">Thrown when Pokemon is not found</exception>
        /// <returns></returns>
        public async Task<Pokemon> GetPokemonByName(string name)
        {

            name = name.ToLower(); // Pokemon name must be lowercase

            string url = $"https://pokeapi.co/api/v2/pokemon/{name}";
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode) {

                string responseBody = await response.Content.ReadAsStringAsync(); //Puts it in a big string
                return JsonConvert.DeserializeObject<Pokemon>(responseBody);
            }
            else if(response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new ArgumentException($"{name} does not exist");
            }
            else
            {
                throw new HttpRequestException();
            }

        }

        public void GetPokemonById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
