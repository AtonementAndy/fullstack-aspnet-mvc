using BeeEngineering.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BeeEngineering.Controllers
{
    public class HomeController : Controller
    {
       
        public IActionResult Index()
        {
            var model = new HomeModel
            {
                Name = "Controle de Candidatos!"
            };
            return View(model);
        }        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}