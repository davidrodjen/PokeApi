﻿using PokeApiCore;
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
            Pokemon result = await myClient.GetPokemonById(1);

            // Sort moves by name alphabetically
            result.moves.OrderBy(m => m.move.name);

            return result;
        }
    }
}
