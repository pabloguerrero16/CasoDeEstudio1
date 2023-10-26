using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Json;
using WebCaso.Entities;
using System.Web;
using System.Web.Mvc;

namespace WebCaso.Models
{
    public class CasoModelo
    {
        public List<SelectListItem> ConsultarCursos()
        {
            using (var client = new HttpClient())
            {
                var url = "https://localhost:44309/ConsultarCursos";
                var resp = client.GetAsync(url).Result;
                return resp.Content.ReadFromJsonAsync<List<SelectListItem>>().Result;
            }
        }

        public string Matricular(EstudianteEnt ent)
        {
            using (var client = new HttpClient())
            {
                var url = "https://localhost:44309/Matricular";
                JsonContent contenido = JsonContent.Create(ent);
                var resp = client.PostAsync(url, contenido).Result;
                return resp.Content.ReadFromJsonAsync<string>().Result;
            }
        }
    }
}