using System;

namespace ProyectoMVC.Models
{
    public class Evaluacion:ObjetoEscuelaBase
    {
        public Alumno Alumno { get; set; }
        public string AlumnoId { get; set; }
        
        public Asignatura Asignatura  { get; set; }

        public string AsignaturaId { get; set; }

        public float Nota { get; set; }

        public override string ToString()
        {
            return $"{Nota}, {Alumno.Nombre}, {Asignatura.Nombre}";
        }
    }
}