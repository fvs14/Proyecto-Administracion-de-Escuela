using System;
using Microsoft.AspNetCore.Mvc;
using ProyectoMVC.Models;


using System.Linq;
using System.Collections.Generic;
using ProyectoMVC.Models;

namespace ProyectoMVC.Controllers
{
    public class AlumnoController : Controller
    {
        public IActionResult Inicio()
        {
           var Alumno=new Alumno();
            Alumno.Nombre="Pepe Perez";
            Alumno.Id= Guid.NewGuid().ToString();
           
            return View(Alumno);


        }

         public IActionResult MultiAlumno()
        {
            var listaAlumnos = new List<Alumno>(){
                            new Alumno{Nombre="Juan Ramirez",
                                Id= Guid.NewGuid().ToString()
                            } ,
                            new Alumno{Nombre="Ana Lopez",
                                Id= Guid.NewGuid().ToString()
                            },
                            new Alumno{Nombre="Juanito Sanchez",
                                Id= Guid.NewGuid().ToString()
                            },
                            new Alumno{Nombre="Pedro Cascante",
                               Id= Guid.NewGuid().ToString()
                            }
                            ,
                            new Alumno{Nombre="Kevin Perez",
                                Id= Guid.NewGuid().ToString()
                            }
                };

            return View("MultiAlumno", listaAlumnos);
        }
    }
}
