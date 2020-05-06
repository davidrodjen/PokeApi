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

        public async Task<IActionResult> Index(int? id)
        {
            // Set it to id, but if it is null, set it to 1
            int desiredId = id ?? 1;
            ViewData["Id"] = desiredId;

            Pokemon result = await PokeAPIHelper.GetById(desiredId);
            // Method that can be used with Lambda
            //List<Pokemon> temp;
            //temp.OrderBy(p => p.name)

            // Refactor property names
            PokedexEntryViewModel entry = PokeAPIHelper.GetPokedexEntryFromPokemon(result); //Convert to a pokemon object

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
