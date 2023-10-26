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
    public class EstudianteController : ApiController
    {
        
        [HttpPost]
        [Route("Matricular")]
        public String Matricular(EstudianteEnt entidad)
        {
            try
            {
                using (var context = new CasoEstudioMNEntities())
                {
                    var conteo = context.Estudiantes.Count(e => e.TipoCurso == entidad.TipoCurso);
                    
                    if (conteo >= 3)
                    {
                        return "CAPACIDAD MÁXIMA";
                    }
                    else
                    {
                        var user = new Estudiantes();
                        user.Nombre = entidad.Nombre;
                        user.Fecha = DateTime.Now;
                        user.Monto = entidad.Monto;
                        user.TipoCurso = entidad.TipoCurso;

                        context.Estudiantes.Add(user);
                        context.SaveChanges();
                        return "OK";
                    }
                }    

            }catch (Exception){
                return string.Empty;
            }
        }
    }
}
