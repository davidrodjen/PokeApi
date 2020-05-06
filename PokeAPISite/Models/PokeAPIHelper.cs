using PokeApiCore;
using PokeAPISite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokeApiWebsite.Models
{
    public static class PokeAPIHelper
    {
        /// <summary>
        /// get a pokemon by id, moves will be sorted in 
        /// alphabetical order
        /// </summary>
        /// <param name="desiredId"></param>
        /// <returns></returns>
        public static async Task<Pokemon> GetById(int desiredId)
        {

            PokeApiClient myClient = new PokeApiClient();
            Pokemon result = await myClient.GetPokemonById(desiredId);

            // Sort moves by name alphabetically
            result.moves.OrderBy(m => m.move.name);

            return result;
        }


        public static PokedexEntryViewModel GetPokedexEntryFromPokemon(Pokemon result)
        {
            var entry = new PokedexEntryViewModel()
            {
                Id = result.id,
                Name = result.name,
                Height = result.height.ToString(),
                Weight = result.weight.ToString(),
                PokedexImageUrl = result.sprites.front_default,
                MoveList = result.moves
                                .OrderBy(m => m.move.name)
                                .Select(m => m.move.name)
                                .ToArray() // Sorts and arranges by the Array

                // MoveList = (from m in result.moves
                //              orderBy m.move.name ascending
                //              select m.move.name).ToArray()
            };

            // Uppercase the first letter of each Pokedex name, didn't use the extension method
            entry.Name = entry.Name[0].ToString().ToUpper() +
                         entry.Name.Substring(1);
            return entry;
        }
    }
}