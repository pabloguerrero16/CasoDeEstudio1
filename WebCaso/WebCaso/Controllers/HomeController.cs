using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebCaso.Entities;
using WebCaso.Models;

namespace WebCaso.Controllers
{
    public class HomeController : Controller
    {

        CasoModelo model = new CasoModelo();


        [HttpGet]
        public ActionResult Index()
        {
            ServicePointManager.ServerCertificateValidationCallback += (o, c, ch, er) => true;
            return View();

        }

        [HttpGet]
        public ActionResult Matricula()
        {
            ViewBag.Cursos = model.ConsultarCursos();
            return View();
        }

        [HttpPost]
        public ActionResult Matricula(EstudianteEnt entidad) 
        {
            var resp = model.Matricular(entidad);
            if(resp == "OK" ||  resp == "CAPACIDAD MÁXIMA")
            {
                if (resp == "OK")
                {
                    TempData["Exito"] = "Se ha matriculado con éxito";
                }
                else if (resp == "CAPACIDAD MÁXIMA")
                {
                    TempData["Maximo"] = "El curso se encuentra a máxima capacidad";
                }
                return RedirectToAction("Matricula", "Home");

            }
            else
            {
                TempData["Error"] = "No se ha podido matricular";
                return RedirectToAction("Matricula", "Home");
            }
        }
    }
}