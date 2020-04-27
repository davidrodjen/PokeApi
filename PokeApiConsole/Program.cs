using PokeApiCore;
using System;
using System.Threading.Tasks;

namespace PokeApiConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            PokeApiClient client = new PokeApiClient();
            string result = await client.GetPokemonByName("bulbasaur");
            Console.WriteLine(result);

            Console.ReadKey();
        }
    }
}
