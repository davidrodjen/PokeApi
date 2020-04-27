using System;
using System.Net.Http;

namespace PokeApiCore
{

    /// <summary>
    /// Client class to consume PokeApi
    /// https://pokeapi.co/
    /// Had to add Nuget pckg, System.net.http;
    /// </summary>
    public class PokeApiClient
    {
        static readonly HttpClient client = new HttpClient();

        public void GetPokemonByName(string name)
        {
            throw new NotImplementedException();
        }

        public void GetPokemonById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
