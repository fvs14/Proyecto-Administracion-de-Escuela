using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace ProyectoMVC.Models
{
    public class Grupo:ObjetoEscuelaBase
    {
        [Required] 
        public override string Nombre { get; set; }
        
        public TiposJornada Jornada { get; set; }
        public string EscuelaId { get; set; }

        
        //  public List<Asignatura> Asignaturas{ get; set; }
        //  public List<Alumno> Alumnos{ get; set; }

        // public string Dirección { get; set; }
    
        // public Escuela Escuela { get; set; }

    }
}