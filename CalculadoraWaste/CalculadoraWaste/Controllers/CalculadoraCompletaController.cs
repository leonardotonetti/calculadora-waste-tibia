using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CalculadoraWaste.Controllers
{
    public class CalculadoraCompletaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}