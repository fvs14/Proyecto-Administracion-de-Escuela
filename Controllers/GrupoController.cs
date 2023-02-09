using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProyectoMVC.Models;

namespace ProyectoMVC.Controllers
{
    public class GrupoController : Controller
    {
        private EscuelaContext _context;
        

         public IActionResult MultiGrupo()
        {
            var escuela=_context.Grupos.ToList();
           return View(escuela);
        }
        //solo dibuja la vista cuando es llamada
         public IActionResult CrearGrupo()
        {
           
           return View();
        }
        //metodo POST para enviar el objeto grupo
        [HttpPost]
         public IActionResult CrearGrupo(Grupo grupo)
        {   var escuela=_context.Escuelas.FirstOrDefault();
            grupo.EscuelaId= escuela.Id;
            grupo.Id=Guid.NewGuid().ToString();
            Console.WriteLine(grupo.Id+"...."+grupo.EscuelaId+"...."+grupo.Nombre+"...."+grupo.Jornada+"....");
            ModelState.Remove("Id");
            ModelState.Remove("EscuelaId");
            if(ModelState.IsValid){
                _context.Grupos.Add(grupo);
                _context.SaveChanges();

                var grupolist=_context.Grupos.ToList();
                
                return View("MultiGrupo",grupolist);
            }else{
                return View(grupo);
            }
        }


        public GrupoController (EscuelaContext context){
            _context = context;
        }

        
    }
    
}