using ActivoFijoGrupo6.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Drawing;
using Microsoft.Extensions.Options;

namespace ActivoFijoGrupo6.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static List<ActivoFijoModel> _activosFijoslList = new List<ActivoFijoModel>();
        
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(_activosFijoslList);
        }

        public IActionResult ActivoFijo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ActivoFijo(IFormCollection formCollection)
        {
            if (ModelState.IsValid)
            {
                string codigo = string.Empty, nombres = string.Empty, precio = string.Empty;
                if (formCollection.ContainsKey("Codigo"))
                {
                    codigo = formCollection["Codigo"];
                }
                if (formCollection.ContainsKey("Nombres"))
                {
                    nombres = formCollection["Nombres"];
                }
                if (formCollection.ContainsKey("Precio"))
                {
                    precio = formCollection["Precio"];
                }

                var keys = formCollection.Keys.Select(k => k).Where(k => k.Contains("Atributo")).ToList();
                List<string> atributosNombre = new List<string>();
                List<string> atributoValor = new List<string>();
                foreach (var key in keys)
                {
                    if (key.Contains("Nombre"))
                      atributosNombre.Add(formCollection[key]);
                  
                    if (key.Contains("Valor"))
                      atributoValor.Add(formCollection[key]);
                }
                var builder = new ActivoFijoModel.Builder()
                    .SetNombres(nombres)
                    .SetCodigo(codigo)
                    .SetPrecio(Convert.ToDouble(precio));

                for (int i = 0; i < atributosNombre.Count; i++)
                {
                    builder.SetAtributoOpcional(nombre: atributosNombre[i], valor: atributoValor[i]);
                }
                _activosFijoslList.Add(
                  builder
                  .Build());
                return RedirectToAction("Index");
            }
            return View();
        }
    
        public IActionResult ActivoFijoList()
        {
            return View(_activosFijoslList);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}