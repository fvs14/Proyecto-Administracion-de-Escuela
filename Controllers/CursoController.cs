using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProyectoMVC.Models;

namespace ProyectoMVC.Controllers
{
    public class CursoController : Controller
    {
        private EscuelaContext _context;
        

         public IActionResult MultiCurso()
        {
            // var listaAlumnos = new List<Alumno>(){
            //                 new Alumno{Nombre="Juan Ramirez",
            //                     Id= Guid.NewGuid().ToString()
            //                 } ,
            //                 new Alumno{Nombre="Ana Lopez",
            //                     Id= Guid.NewGuid().ToString()
            //                 },
            //                 new Alumno{Nombre="Juanito Sanchez",
            //                     Id= Guid.NewGuid().ToString()
            //                 },
            //                 new Alumno{Nombre="Pedro Cascante",
            //                    Id= Guid.NewGuid().ToString()
            //                 }
            //                 ,
            //                 new Alumno{Nombre="Kevin Perez",
            //                     Id= Guid.NewGuid().ToString()
            //                 }
            //     };

            // return View("MultiAlumno", listaAlumnos);

            var escuela=_context.Cursos.ToList();
           return View(escuela);
        }

        public CursoController (EscuelaContext context){
            _context = context;
        }

        
    }
    
}