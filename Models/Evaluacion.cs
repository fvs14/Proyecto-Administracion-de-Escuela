using System;
using System.ComponentModel.DataAnnotations;

namespace ProyectoMVC.Models
{
    public class Evaluacion
    {
        // public List<Alumno> Alumno { get; set; }
        public string AlumnoId { get; set; }
        
        // public List<Asignatura> Asignatura  { get; set; }

         public string AsignaturaId { get; set; }

        public decimal Nota { get; set; }
        
        public string Id { get; set; }

        


        // public override string ToString()
        // {
        //     return $"{Nota}, {Alumno.Nombre}, {Asignatura.Nombre}";
        // }
    }
}