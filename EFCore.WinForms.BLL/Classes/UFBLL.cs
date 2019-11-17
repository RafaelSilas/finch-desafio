using Newtonsoft.Json;
using EFCore.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.WinForms.BLL
{
    public class UFBLL
    {
        public List<UFs> listaUfs = null;
        public UFs ufs = null;
        public bool resultado = false;

        public async Task<List<UFs>> GetUfsAsync(string webApi)
        {
            try
            {
                HttpClient client = new HttpClient();
                var response = await client.GetStringAsync(webApi + "GetListaUFs");
                listaUfs = JsonConvert.DeserializeObject<List<UFs>>(response);
                return listaUfs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UFs> GetUfsAsync(string webApi, int idUfs)
        {
            try
            {
                HttpClient client = new HttpClient();
                var response = await client.GetStringAsync(webApi + "GetUf/" + idUfs);
                ufs = JsonConvert.DeserializeObject<UFs>(response);
                return ufs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<bool> PostUfAsync(string webApi, UFs Uf)
        {
            using (var client = new HttpClient())
            {
                var serializedUf = JsonConvert.SerializeObject(Uf);
                var content = new StringContent(serializedUf, Encoding.UTF8, "application/json");
                var result = await client.PostAsync(webApi + "PostUf", content);
                resultado = result.IsSuccessStatusCode;
                return resultado;
            }
        }

        private async Task<bool> PutUfAsync(string webApi, UFs Uf)
        {
            using (var client = new HttpClient())
            {
                var serializedUf = JsonConvert.SerializeObject(Uf);
                var content = new StringContent(serializedUf, Encoding.UTF8, "application/json");
                var result = await client.PutAsync(webApi + "PutUf/" + Uf.idUf, content);
                resultado = result.IsSuccessStatusCode;
                return resultado;
            }
        }

        public async Task<bool> DeleteUfAsync(string webApi, int idUf)
        {
            try
            {
                HttpClient client = new HttpClient();
                var result = await client.DeleteAsync(webApi + "DeleteUf/" + idUf);
                resultado = result.IsSuccessStatusCode;
                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string ValidarSalvar(UFs uf)
        {
            string validacao = string.Empty; 

            if (string.IsNullOrEmpty(uf.Descricao))
            {
                validacao += "\r\nInforme a Descrição!";
            }

            return validacao;
        }

        public async Task<bool> SalvarUF(string webApi, UFs uf)
        {
            try
            {
                string validacao = ValidarSalvar(uf);
                if (string.IsNullOrEmpty(validacao))
                {
                    if (uf.idUf > 0)
                    {
                        resultado = await PutUfAsync(webApi, uf);
                        return resultado;
                    }
                    else
                    {
                        resultado = await PostUfAsync(webApi, uf);
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
