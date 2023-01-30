using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProyectoMVC.Models
{
    public class EscuelaContext : DbContext
    {
        public DbSet<Escuela> Escuelas { get; set; }
        public DbSet<Asignatura> Asignaturas { get; set; }
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Evaluación> Evaluaciones { get; set; }

        

        public EscuelaContext(DbContextOptions<EscuelaContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var escuela = new Escuela();
            escuela.AñoDeCreación = 2005;
            escuela.Id = Guid.NewGuid().ToString();
            escuela.Nombre = "Platzi School";
            escuela.Ciudad = "Bogota";
            escuela.Pais = "Colombia";
            escuela.Dirección = "Avd Siempre viva";
            escuela.TipoEscuela = TiposEscuela.Secundaria;

            modelBuilder.Entity<Escuela>().HasData(escuela);

            modelBuilder.Entity<Asignatura>().HasData(
                           new Asignatura
                           {
                               Nombre = "Matemáticas",
                               Id = Guid.NewGuid().ToString()
                           },
                            new Asignatura
                            {
                                Nombre = "Educación Física",
                                Id= Guid.NewGuid().ToString()
                            },
                            new Asignatura
                            {
                                Nombre = "Castellano",
                                Id = Guid.NewGuid().ToString()
                            },
                            new Asignatura
                            {
                                Nombre = "Ciencias Naturales",
                                Id = Guid.NewGuid().ToString()
                            }
                            ,
                            new Asignatura
                            {
                                Nombre = "Programación",
                                Id = Guid.NewGuid().ToString()
                            }
                           );

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

            modelBuilder.Entity<Alumno>()
                        .HasData(listaAlumnos.ToArray());
        }

        
    }
}