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
        static readonly HttpClient client;

        static PokeApiClient()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://pokeapi.co/api/v2/");
            client.DefaultRequestHeaders.Add("User-Agent", "David's PokeAPI");
        }

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
            return await GetPokemonByNameOrId(name);
        }

        
        public static async Task<Pokemon> GetPokemonByNameOrId(string name)
        {
            string url = $"pokemon/{name}";
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {

                string responseBody = await response.Content.ReadAsStringAsync(); //Puts it in a big string
                return JsonConvert.DeserializeObject<Pokemon>(responseBody);
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new ArgumentException($"{name} does not exist");
            }
            else
            {
                throw new HttpRequestException();
            }
        }

        /// <summary>
        /// Gets a pokemon by their Pokedex ID number
        /// </summary>
        /// <param name="id">the id of the Pokemon</param>
        /// <returns></returns>
        public async Task<Pokemon> GetPokemonById(int id)
        {
            return await GetPokemonByNameOrId(id.ToString());
        }
    }
}
