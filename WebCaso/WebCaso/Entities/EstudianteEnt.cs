using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCaso.Entities
{
    public class EstudianteEnt
    {
        public int Consecutivo { get; set; }
        public string Nombre { get; set; }
        public DateTime fecha { get; set; }
        public decimal Monto {get; set; }
        public int TipoCurso { get; set; }
        public string nombreCurso {  get; set; }


    }
}