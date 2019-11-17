using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using EFCore.Dominio;

namespace EFCore.WinForms.BLL
{
    public class ProtestoBLL
    {
        public List<Protestos> listaProtestos = null;
        public Protestos protesto = null;
        public bool resultado = false;

        public async Task<List<Protestos>> GetProtestosAsync(string webApi)
        {
            try
            {
                HttpClient client = new HttpClient();
                var response = await client.GetStringAsync(webApi + "GetListaProtestos");
                listaProtestos = JsonConvert.DeserializeObject<List<Protestos>>(response);
                return listaProtestos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Protestos> GetProtestoAsync(string webApi, int idProtesto)
        {
            try
            {
                HttpClient client = new HttpClient();
                var response = await client.GetStringAsync(webApi + "GetProtesto/" + idProtesto);
                protesto = JsonConvert.DeserializeObject<Protestos>(response);
                return protesto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<bool> PostProtestoAsync(string webApi, Protestos protesto)
        {
            using (var client = new HttpClient())
            {
                var serializedProtesto = JsonConvert.SerializeObject(protesto);
                var content = new StringContent(serializedProtesto, Encoding.UTF8, "application/json");
                var result = await client.PostAsync(webApi + "PostProtesto", content);
                resultado = result.IsSuccessStatusCode;
                return resultado;
            }
        }

        private async Task<bool> PutProtestoAsync(string webApi, Protestos protesto)
        {
            using (var client = new HttpClient())
            {
                var serializedProtesto = JsonConvert.SerializeObject(protesto);
                var content = new StringContent(serializedProtesto, Encoding.UTF8, "application/json");
                var result = await client.PutAsync(webApi + "PutProtesto/" + protesto.idProtesto, content);
                resultado = result.IsSuccessStatusCode;
                return resultado;
            }
        }

        public async Task<bool> DeleteProtestoAsync(string webApi, int idProtesto)
        {
            try
            {
                HttpClient client = new HttpClient();
                var result = await client.DeleteAsync(webApi + "DeleteProtesto/" + idProtesto);
                resultado = result.IsSuccessStatusCode;
                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string ValidarSalvar(Protestos protesto)
        {
            string validacao = string.Empty;

            return validacao;
        }

        public async Task<bool> SalvarProtesto(string webApi, Protestos protesto)
        {
            try
            {
                string validacao = ValidarSalvar(protesto);
                if (string.IsNullOrEmpty(validacao))
                {
                    if (protesto.idProtesto > 0)
                    {
                        resultado = await PutProtestoAsync(webApi, protesto);
                        return resultado;
                    }
                    else
                    {
                        resultado = await PostProtestoAsync(webApi, protesto);
                        return resultado;
                    }
                }
                else
                {
                    resultado = false;
                    throw new ArgumentException(validacao);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
