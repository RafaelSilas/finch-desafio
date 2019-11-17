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
    public class DevedorBLL
    {
        public List<Devedores> listaDevedores = null;
        public Devedores devedor = null;
        public bool resultado = false;

        public async Task<List<Devedores>> GetDevedoresAsync(string webApi)
        {
            try
            {
                HttpClient client = new HttpClient();
                var response = await client.GetStringAsync(webApi + "GetListaDevedores");
                listaDevedores = JsonConvert.DeserializeObject<List<Devedores>>(response);
                return listaDevedores;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Devedores> GetDevedorAsync(string webApi, int idDevedor)
        {
            try
            {
                HttpClient client = new HttpClient();
                var response = await client.GetStringAsync(webApi + "GetDevedor/" + idDevedor);
                devedor = JsonConvert.DeserializeObject<Devedores>(response);
                return devedor;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private async Task<bool> PostDevedorAsync(string webApi, Devedores devedor)
        {
            using (var client = new HttpClient())
            {
                var serializedDevedor = JsonConvert.SerializeObject(devedor);
                var content = new StringContent(serializedDevedor, Encoding.UTF8, "application/json");
                var result = await client.PostAsync(webApi + "PostDevedor", content);
                resultado = result.IsSuccessStatusCode;
                return resultado;
            }
        }

        private async Task<bool> PutDevedorAsync(string webApi, Devedores devedor)
        {
            using (var client = new HttpClient())
            {
                var serializedDevedor = JsonConvert.SerializeObject(devedor);
                var content = new StringContent(serializedDevedor, Encoding.UTF8, "application/json");
                var result = await client.PutAsync(webApi + "PutDevedor/" + devedor.idDevedor, content);
                resultado = result.IsSuccessStatusCode;
                return resultado;
            }
        }

        public async Task<bool> DeleteDevedorAsync(string webApi, int idDevedor)
        {
            try
            {
                HttpClient client = new HttpClient();
                var result = await client.DeleteAsync(webApi + "DeleteDevedor/" + idDevedor);
                resultado = result.IsSuccessStatusCode;
                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string ValidarSalvar(Devedores devedor)
        {
            string validacao = string.Empty;

            if (string.IsNullOrEmpty(devedor.CPF_CNPJ))
            {
                validacao += "\r\nInforme o CPF do Devedor!";
            }

            if (string.IsNullOrEmpty(devedor.Nome))
            {
                validacao += "\r\nInforme o Nome do Devedor!";
            }

            return validacao;
        }

        public async Task<bool> SalvarDevedor(string webApi, Devedores devedor)
        {
            try
            {
                string validacao = ValidarSalvar(devedor);
                if (string.IsNullOrEmpty(validacao))
                {
                    if (devedor.idDevedor > 0)
                    {
                        resultado = await PutDevedorAsync(webApi, devedor);
                        return resultado;
                    }
                    else
                    {
                        resultado = await PostDevedorAsync(webApi, devedor);
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
