using System;
using Microsoft.AspNetCore.Mvc;
using ProyectoMVC.Models;

namespace ProyectoMVC.Controllers
{
    public class AlumnoController : Controller
    {
        public IActionResult Inicio()
        {
           var Alumno=new Alumno();
            Alumno.Nombre="Pepe Perez";
             Alumno.UniqueId= Guid.NewGuid().ToString();
           
            return View(Alumno);


        }

         public IActionResult MultiAlumno()
        {
            var listaAlumnos = new List<Alumno>(){
                            new Alumno{Nombre="Juan Ramirez",
                                UniqueId= Guid.NewGuid().ToString()
                            } ,
                            new Alumno{Nombre="Ana Lopez",
                                UniqueId= Guid.NewGuid().ToString()
                            },
                            new Alumno{Nombre="Juanito Sanchez",
                                UniqueId= Guid.NewGuid().ToString()
                            },
                            new Alumno{Nombre="Pedro Cascante",
                                UniqueId= Guid.NewGuid().ToString()
                            }
                            ,
                            new Alumno{Nombre="Kevin Perez",
                                UniqueId= Guid.NewGuid().ToString()
                            }
                };

            return View("MultiAlumno", listaAlumnos);
        }
    }
}
