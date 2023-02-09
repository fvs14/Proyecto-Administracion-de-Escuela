using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProyectoMVC.Models;

namespace ProyectoMVC.Controllers
{
    public class EvaluacionController : Controller
    {
        private EscuelaContext _context;
        

         public IActionResult MultiEvaluacion()
        {

            var escuela=_context.Evaluaciones.ToList();
           return View(escuela);
        }

         public IActionResult CrearEvaluacion()
        {
            var listaAsig=_context.Asignaturas;
            ViewBag.LAsig=listaAsig;
            var listaAlumnos=_context.Alumnos;
            ViewBag.LAlum=listaAlumnos;
           
           return View();
        }
        [HttpPost]
         public IActionResult CrearEvaluacion(Evaluacion evaluacion)
        {
           
            evaluacion.Id=Guid.NewGuid().ToString();
            ModelState.Remove("Id");
            Console.WriteLine(evaluacion.Nota);
             if(ModelState.IsValid){
                _context.Evaluaciones.Add(evaluacion);
                _context.SaveChanges();
                var evlist=_context.Evaluaciones.ToList();
                
                return View("MultiEvaluacion",evlist);
            }else{
                var listaAsig=_context.Asignaturas;
                ViewBag.LAsig=listaAsig;
                var listaAlumnos=_context.Alumnos;
                ViewBag.LAlum=listaAlumnos;
                return View(evaluacion);
            }
        }

        public EvaluacionController (EscuelaContext context){
            _context = context;
        }

        
    }
    
}