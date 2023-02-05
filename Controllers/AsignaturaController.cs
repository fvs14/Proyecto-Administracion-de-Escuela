using System;
using Microsoft.AspNetCore.Mvc;
using ProyectoMVC.Models;

namespace ProyectoMVC.Controllers
{
    public class AsignaturaController : Controller
    {
        private EscuelaContext _context;
        public IActionResult Inicio()
        {
        //    var Asignatura=new Asignatura();
        //     Asignatura.Nombre="Español";
        //      Asignatura.Id= Guid.NewGuid().ToString();
           
        //     return View(Asignatura);
         var escuela=_context.Asignaturas.FirstOrDefault();
           return View(escuela);



        }

         public IActionResult MultiAsignatura()
        {
        //     var listaAsignaturas = new List<Asignatura>(){
        //                     new Asignatura{Nombre="Matemáticas",
        //                         Id= Guid.NewGuid().ToString()
        //                     } ,
        //                     new Asignatura{Nombre="Educación Física",
        //                         Id= Guid.NewGuid().ToString()
        //                     },
        //                     new Asignatura{Nombre="Castellano",
        //                         Id= Guid.NewGuid().ToString()
        //                     },
        //                     new Asignatura{Nombre="Ciencias Naturales",
        //                         Id= Guid.NewGuid().ToString()
        //                     }
        //                     ,
        //                     new Asignatura{Nombre="Programación",
        //                         Id= Guid.NewGuid().ToString()
        //                     }
        //         };

        //     return View("MultiAsignatura", listaAsignaturas);

        //-----ya que definimos una lista tiapda , queramos que nuestra vista reciba una lista:--------------   
        //    var escuela=_context.Asignaturas.ToList();
        //    return View(escuela);

        //-----en caso de que queramos que nuestra vista tipada reciba los datos usar:--------------
        //-----la vista debe tner el formato tipado IEUNUMERABLE:--------------
           return View("MultiAsignatura",_context.Asignaturas);
        }

        public AsignaturaController (EscuelaContext context){
            _context = context;
        }

        
        
    }
}
