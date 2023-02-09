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
        public DbSet<Grupo> Grupos { get; set; }
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

            //Cargar grupos de la Escuela
            var grupos = CargarGrupos(escuela);

            //x cada curso cargar asignaturas
            var asignaturas = CargarAsignaturas(grupos);

             //x cada curso cargar alumnos
            var alumnos = CargarAlumnos(grupos);

            var evaluaciones= CargarEvaluacion(alumnos,asignaturas);

           
            modelBuilder.Entity<Escuela>().HasData(escuela);
            modelBuilder.Entity<Grupo>().HasData(grupos.ToArray());
            modelBuilder.Entity<Asignatura>().HasData(asignaturas.ToArray());
            modelBuilder.Entity<Alumno>().HasData(alumnos.ToArray());
            modelBuilder.Entity<Evaluacion>().HasData(evaluaciones.ToArray());
                   
        }

        private static List<Evaluacion> CargarEvaluacion(List<Alumno> alumnos,List<Asignatura> asignaturas)
        {
            var listaEvaluacion = new List<Evaluacion> ();

            Random rnd = new Random();
            Random r = new Random();
            int range = 100;
            foreach(var alumno in alumnos){
                
                    foreach(var asignatura in asignaturas){
                        if(alumno.GrupoId==asignatura.GrupoId){
                            double num =r.NextDouble()* range;
                            decimal num2=Math.Round((decimal)num, 2);
                            var tmplist = new List<Evaluacion> {
                                        new Evaluacion{Id = Guid.NewGuid().ToString(),AlumnoId = alumno.Id,AsignaturaId=asignatura.Id,Nota=num2}
                                        };
                            listaEvaluacion.AddRange(tmplist);
                        }
                    }
                    
                
            }
            return listaEvaluacion;
        }

        private List<Alumno> CargarAlumnos(List<Grupo> grupos)
        {
            var listaAlumnos = new List<Alumno>();

            Random rnd = new Random();
            foreach (var grupo in grupos)
            {
                int cantRandom = rnd.Next(1, 4);
                var tmplist = GenerarAlumnosAlAzar(grupo, cantRandom);
                listaAlumnos.AddRange(tmplist);
            }
            return listaAlumnos;
        }

          private static List<Asignatura> CargarAsignaturas(List<Grupo> grupos)
        {
            var listaCompleta = new List<Asignatura> ();
            foreach (var grupo in grupos)
            {
                var tmpList = new List<Asignatura> {
                            new Asignatura{Id = Guid.NewGuid().ToString(),GrupoId = grupo.Id,Nombre="Matemáticas"} ,
                            new Asignatura{Id = Guid.NewGuid().ToString(), GrupoId = grupo.Id, Nombre="Estudios Sociales"},
                            new Asignatura{Id = Guid.NewGuid().ToString(), GrupoId = grupo.Id, Nombre="Español"},
                            new Asignatura{Id = Guid.NewGuid().ToString(), GrupoId = grupo.Id, Nombre="Ciencias"},
                            new Asignatura{Id = Guid.NewGuid().ToString(), GrupoId = grupo.Id, Nombre="Inglés"}
                };
                listaCompleta.AddRange(tmpList);
                //curso.Asignaturas = tmpList;
            }

            return listaCompleta;
        }


         private static List<Grupo> CargarGrupos(Escuela escuela)
        {
            return new List<Grupo>(){
                        new Grupo() {Id = Guid.NewGuid().ToString(),EscuelaId = escuela.Id,Nombre = "A1",Jornada = TiposJornada.Mañana },
                        new Grupo() {Id = Guid.NewGuid().ToString(), EscuelaId = escuela.Id, Nombre = "A2", Jornada = TiposJornada.Mañana},
                        new Grupo() {Id = Guid.NewGuid().ToString(), EscuelaId = escuela.Id, Nombre = "A3", Jornada = TiposJornada.Mañana},
                        new Grupo() {Id = Guid.NewGuid().ToString(), EscuelaId = escuela.Id, Nombre = "B1", Jornada = TiposJornada.Tarde },
                        new Grupo() {Id = Guid.NewGuid().ToString(), EscuelaId = escuela.Id, Nombre = "B2", Jornada = TiposJornada.Tarde},
                        new Grupo() {Id = Guid.NewGuid().ToString(), EscuelaId = escuela.Id, Nombre = "C1", Jornada = TiposJornada.Noche}
            };
        }

        private List<Alumno> GenerarAlumnosAlAzar(
            Grupo grupo,
            int cantidad)
        {
            string[] nombre = { "Alba", "Felipe", "Ernesto", "Andrea", "María", "Andres", "Nicolás" };
            string[] apellido1 = { "Ruiz", "Sanchez", "Uribe", "Martinez", "Jimenez", "Toledo", "Herrera" };
            string[] apellido2 = { "Alvarado", "Vindas", "Perez", "Murillo", "Soza", "Garita", "Arroyo", "Tencio" };

            var listaAlumnos = from n1 in nombre
                               from a1 in apellido1
                               from a2 in apellido2
                               select new Alumno
                               {
                                   GrupoId = grupo.Id,
                                   Nombre = $"{n1} {a2} {a1}",
                                   Id = Guid.NewGuid().ToString()
                               };

            return listaAlumnos.OrderBy((al) => al.Id).Take(cantidad).ToList();
        }

        
    }
}