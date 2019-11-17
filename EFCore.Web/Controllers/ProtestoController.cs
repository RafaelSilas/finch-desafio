using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using EFCore.Dominio;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EFCore.Web.Controllers
{
    public class ProtestoController : Controller
    {
        private const string URL_API = "http://localhost:52738/protestowebapi/";

        public async Task<IActionResult> Index()
        {
            await PostProtestoAsync(new Protestos()
            {
                idProtesto = 1,
                Contrato = 2,
                Valor = 110,
                Vencimento = new DateTime(2019, 10, 10),
                DataEmissao = new DateTime(2019, 10, 10),
                Operacao = "p",
                TipoDocumento = "e"
            });
            return View();
        }

        private async Task<bool> PostProtestoAsync(Protestos protesto)
        {
            bool resultado = false;

            using (var client = new HttpClient())
            {
                var serializedTitulo = JsonConvert.SerializeObject(protesto);
                var content = new StringContent(serializedTitulo, Encoding.UTF8, "application/json");
                var result = await client.PostAsync(URL_API + "PostProtesto", content);
                resultado = result.IsSuccessStatusCode;
                return resultado;
            }
        }
    }
}