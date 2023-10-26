using ApiCaso.Entities;
using ApiCaso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiCaso.Controllers
{
    public class MatriculaController : ApiController
    {

        [HttpGet]
        [Route("ConsultarMatriculas")]
        public List<EstudianteEnt> ConsultarMatriculas()
        {
            try
            {
                using (var context = new CasoEstudioMNEntities())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    var datos = (from x in context.Estudiantes
                                 join v in context.TiposCursos on x.TipoCurso equals v.TipoCurso
                                 select new EstudianteEnt
                                 {
                                     fecha = x.Fecha,
                                     Monto = x.Monto,
                                     NombreCurso = v.DescripcionTipoCurso,
                                     Nombre = x.Nombre
                                 }).ToList();
                    return datos;
                }
            }catch (Exception)
            {
                return null;
            }
        }
    }
}
