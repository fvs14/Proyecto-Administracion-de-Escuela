using System;
using Microsoft.AspNetCore.Mvc;
using ProyectoMVC.Models;

namespace ProyectoMVC.Controllers
{
    public class AsignaturaController : Controller
    {
        public IActionResult Inicio()
        {
           var Asignatura=new Asignatura();
            Asignatura.Nombre="Español";
             Asignatura.Id= Guid.NewGuid().ToString();
           
            return View(Asignatura);


        }

         public IActionResult MultiAsignatura()
        {
            var listaAsignaturas = new List<Asignatura>(){
                            new Asignatura{Nombre="Matemáticas",
                                Id= Guid.NewGuid().ToString()
                            } ,
                            new Asignatura{Nombre="Educación Física",
                                Id= Guid.NewGuid().ToString()
                            },
                            new Asignatura{Nombre="Castellano",
                                Id= Guid.NewGuid().ToString()
                            },
                            new Asignatura{Nombre="Ciencias Naturales",
                                Id= Guid.NewGuid().ToString()
                            }
                            ,
                            new Asignatura{Nombre="Programación",
                                Id= Guid.NewGuid().ToString()
                            }
                };

            return View("MultiAsignatura", listaAsignaturas);
        }
    }
}
