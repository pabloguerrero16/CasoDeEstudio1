using ApiCaso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiCaso.Controllers
{
    public class CursoController : ApiController
    {
        [HttpGet]
        [Route("ConsultarCursos")]
        public List<System.Web.Mvc.SelectListItem> ConsultarCursos()
        {
            try
            {
                using (var context = new CasoEstudioMNEntities())
                {
                    var datos = (from x in context.TiposCursos
                                 select x).ToList();

                    var respuesta = new List<System.Web.Mvc.SelectListItem>();
                    foreach (var item in datos)
                    {
                        respuesta.Add(new System.Web.Mvc.SelectListItem { Value = item.TipoCurso.ToString(), Text = item.DescripcionTipoCurso });
                    }
                    return respuesta;
                }
            }catch (Exception)
            {
                return null;
            }
        }
    }
}
