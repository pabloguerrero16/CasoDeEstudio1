using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiCaso.Entities
{
    public class EstudianteEnt
    {
        public string Nombre { get; set; }
        public DateTime fecha { get; set; }
        public decimal Monto { get; set; }
        public int TipoCurso { get; set; }
        public string NombreCurso {  get; set; }
    }
}