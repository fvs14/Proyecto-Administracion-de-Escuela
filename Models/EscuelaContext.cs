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
        public DbSet<Evaluacion> Evaluaciones { get; set; }

        

        public EscuelaContext(DbContextOptions<EscuelaContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var escuela = new Escuela();
            escuela.AñoDeCreación = 1980;
            escuela.Id = Guid.NewGuid().ToString();
            escuela.Nombre = "América School";
            escuela.Ciudad = "Goicoechea";
            escuela.Pais = "Costa Rica";
            escuela.Dirección = "San José, Goicoechea calle 20, avenida 2";
            escuela.TipoEscuela = TiposEscuela.Secundaria;

            //Cargar Cursos de la Escuela
            var cursos = CargarCursos(escuela);

            //x cada curso cargar asignaturas
            var asignaturas = CargarAsignaturas(cursos);

             //x cada curso cargar alumnos
            var alumnos = CargarAlumnos(cursos);

            // var evaluaciones= CargarEvaluaciones(cursos);

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
            //                     Id= Guid.NewGuid().ToString()
            //                 }
            //                 ,
            //                 new Alumno{Nombre="Kevin Perez",
            //                     Id= Guid.NewGuid().ToString()
            //                 }
            //                 };
            modelBuilder.Entity<Escuela>().HasData(escuela);
            modelBuilder.Entity<Curso>().HasData(cursos.ToArray());
            modelBuilder.Entity<Asignatura>().HasData(asignaturas.ToArray());
            modelBuilder.Entity<Alumno>().HasData(alumnos.ToArray());
            // modelBuilder.Entity<Evaluacion>().HasData(evaluaciones.ToArray());
                   
        }

        private List<Alumno> CargarAlumnos(List<Curso> cursos)
        {
            var listaAlumnos = new List<Alumno>();

            Random rnd = new Random();
            foreach (var curso in cursos)
            {
                int cantRandom = rnd.Next(5, 20);
                var tmplist = GenerarAlumnosAlAzar(curso, cantRandom);
                listaAlumnos.AddRange(tmplist);
            }
            return listaAlumnos;
        }

          private static List<Asignatura> CargarAsignaturas(List<Curso> cursos)
        {
            var listaCompleta = new List<Asignatura> ();
            foreach (var curso in cursos)
            {
                var tmpList = new List<Asignatura> {
                            new Asignatura{Id = Guid.NewGuid().ToString(),CursoId = curso.Id,Nombre="Matemáticas"} ,
                            new Asignatura{Id = Guid.NewGuid().ToString(), CursoId = curso.Id, Nombre="Estudios Sociales"},
                            new Asignatura{Id = Guid.NewGuid().ToString(), CursoId = curso.Id, Nombre="Español"},
                            new Asignatura{Id = Guid.NewGuid().ToString(), CursoId = curso.Id, Nombre="Ciencias"},
                            new Asignatura{Id = Guid.NewGuid().ToString(), CursoId = curso.Id, Nombre="Inglés"}
                };
                listaCompleta.AddRange(tmpList);
                //curso.Asignaturas = tmpList;
            }

            return listaCompleta;
        }


         private static List<Curso> CargarCursos(Escuela escuela)
        {
            return new List<Curso>(){
                        new Curso() {Id = Guid.NewGuid().ToString(),EscuelaId = escuela.Id,Nombre = "A1",Jornada = TiposJornada.Mañana },
                        new Curso() {Id = Guid.NewGuid().ToString(), EscuelaId = escuela.Id, Nombre = "A2", Jornada = TiposJornada.Mañana},
                        new Curso() {Id = Guid.NewGuid().ToString(), EscuelaId = escuela.Id, Nombre = "A3", Jornada = TiposJornada.Mañana},
                        new Curso() {Id = Guid.NewGuid().ToString(), EscuelaId = escuela.Id, Nombre = "B1", Jornada = TiposJornada.Tarde },
                        new Curso() {Id = Guid.NewGuid().ToString(), EscuelaId = escuela.Id, Nombre = "B2", Jornada = TiposJornada.Tarde},
                        new Curso() {Id = Guid.NewGuid().ToString(), EscuelaId = escuela.Id, Nombre = "C1", Jornada = TiposJornada.Noche}
            };
        }

        private List<Alumno> GenerarAlumnosAlAzar(
            Curso curso,
            int cantidad)
        {
            string[] nombre1 = { "Alba", "Felipe", "Ernesto", "Andrea", "María", "Andres", "Nicolás" };
            string[] apellido1 = { "Ruiz", "Sanchez", "Uribe", "Martinez", "Jimenez", "Toledo", "Herrera" };
            string[] nombre2 = { "Alvarado", "Vindas", "Perez", "Murillo", "Soza", "Garita", "Arroyo", "Tencio" };

            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               select new Alumno
                               {
                                   CursoId = curso.Id,
                                   Nombre = $"{n1} {n2} {a1}",
                                   Id = Guid.NewGuid().ToString()
                               };

            return listaAlumnos.OrderBy((al) => al.Id).Take(cantidad).ToList();
        }

        
    }
}