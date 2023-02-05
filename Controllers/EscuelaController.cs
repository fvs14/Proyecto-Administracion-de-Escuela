using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProyectoMVC.Models;

namespace ProyectoMVC.Controllers
{
    public class EscuelaController : Controller
    {
        private EscuelaContext _context;
        
        public IActionResult Inicio()
        {
          
            ViewBag.Saludo="¡¡¡¡¡¡ Bienvenido !!!!!!!!";
         // se le da al contexto el dbset escuelas declarado en escuelaContext.cs
           var escuela=_context.Escuelas.FirstOrDefault();
           return View(escuela);


        }

        public EscuelaController (EscuelaContext context){
            _context = context;
        }
    }
}


