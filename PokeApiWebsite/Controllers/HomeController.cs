using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PokeApiCore;
using PokeApiWebsite.Models;

namespace PokeApiWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            int desiredId = 1;

            Pokemon result = await PokeAPIHelper.GetById(desiredId);
            // Method that can be used with Lambda
            //List<Pokemon> temp;
            //temp.OrderBy(p => p.name)

            // Refactor property names
            var entry = new PokedexEntryViewModel()
            {
                Id = result.Id,
                Name = result.Name,
                Height = result.Height.ToString(),
                Weight = result.Weight.ToString(),
                PokedexImageURL = result.Sprites.FrontDefault,
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


            return View(entry);
        }

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
