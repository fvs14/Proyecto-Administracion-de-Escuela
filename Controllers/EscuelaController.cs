using System;
using Microsoft.AspNetCore.Mvc;
using ProyectoMVC.Models;

namespace ProyectoMVC.Controllers
{
    public class EscuelaController : Controller
    {
        public IActionResult Inicio()
        {
           var escuela=new Escuela();
            escuela.Nombre="America";
            escuela.AñoDeCreación=2005;
            escuela.UniqueId=Guid.NewGuid().ToString();
            escuela.Ciudad="San José";
            escuela.Pais="Costa Rica";
            escuela.Dirección="Guadalupe";
            escuela.TipoEscuela=TiposEscuela.Secundaria;
            ViewBag.Saludo="¡¡¡¡¡¡Hola a Todos !!!!!!!!";
            return View(escuela);


        }
    }
}


