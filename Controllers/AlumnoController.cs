using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProyectoMVC.Models;

namespace ProyectoMVC.Controllers
{
    public class AlumnoController : Controller
    {
        private EscuelaContext _context;
        public IActionResult Inicio()
        {
       
            var escuela=_context.Alumnos.FirstOrDefault();
           return View(escuela);

        }

         public IActionResult MultiAlumno()
        {
            var escuela=_context.Alumnos.ToList();
           
           return View(escuela);
        }

         public IActionResult CrearAlumno()
        {
            var listaGrupos=_context.Grupos;
            
            ViewBag.LG=listaGrupos;
           
           return View();
        }
        [HttpPost]
         public IActionResult CrearAlumno(Alumno alumno)
        {
           
            alumno.Id=Guid.NewGuid().ToString();
            
             ModelState.Remove("Id");
             if(ModelState.IsValid){
                _context.Alumnos.Add(alumno);
                _context.SaveChanges();

                var alumnolist=_context.Alumnos.ToList();
                
                return View("MultiAlumno",alumnolist);
            }else{
                var listaGrupos=_context.Grupos;
                ViewBag.LG=listaGrupos;
                return View(alumno);
            }
        }

        public AlumnoController (EscuelaContext context){
            _context = context;
        }

        
    }
    
}
