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
         var escuela=_context.Asignaturas.FirstOrDefault();
           return View(escuela);



        }

         public IActionResult MultiAsignatura()
        {
       
        //-----ya que definimos una lista tiapda , queramos que nuestra vista reciba una lista:--------------   
        //    var escuela=_context.Asignaturas.ToList();
        //    return View(escuela);

        //-----en caso de que queramos que nuestra vista tipada reciba los datos usar:--------------
        //-----la vista debe tner el formato tipado IEUNUMERABLE:--------------
           return View("MultiAsignatura",_context.Asignaturas);
        }

         public IActionResult CrearAsignatura()
        {
            var listaGrupos=_context.Grupos;
            
            ViewBag.LG=listaGrupos;
           
           return View();
        }
        [HttpPost]
         public IActionResult CrearAsignatura(Asignatura asignatura)
        {
           
            asignatura.Id=Guid.NewGuid().ToString();
         
             ModelState.Remove("Id");
             if(ModelState.IsValid){
                _context.Asignaturas.Add(asignatura);
                _context.SaveChanges();

                var asiglist=_context.Asignaturas.ToList();
                
                return View("MultiAsignatura",asiglist);
            }else{
                var listaGrupos=_context.Grupos;
                ViewBag.LG=listaGrupos;
                return View(asignatura);
            }
        }



        public AsignaturaController (EscuelaContext context){
            _context = context;
        }

        
        
    }
}
