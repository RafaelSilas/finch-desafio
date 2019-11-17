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
    public class ContratoBLL
    {
        public List<Contratos> listaContratos = null;
        public Contratos contrato = null;
        public bool resultado = false;

        public async Task<List<Contratos>> GetContratosAsync(string webApi)
        {
            try
            {
                HttpClient client = new HttpClient();
                var response = await client.GetStringAsync(webApi + "GetListaContratos");
                listaContratos = JsonConvert.DeserializeObject<List<Contratos>>(response);
                return listaContratos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Contratos> GetContratoAsync(string webApi, int idContrato)
        {
            try
            {
                HttpClient client = new HttpClient();
                var response = await client.GetStringAsync(webApi + "GetContrato/" + idContrato);
                contrato = JsonConvert.DeserializeObject<Contratos>(response);
                return contrato;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<bool> PostContratoAsync(string webApi, Contratos contrato)
        {
            using (var client = new HttpClient())
            {
                var serializedContrato = JsonConvert.SerializeObject(contrato);
                var content = new StringContent(serializedContrato, Encoding.UTF8, "application/json");
                var result = await client.PostAsync(webApi + "PostContrato", content);
                resultado = result.IsSuccessStatusCode;
                return resultado;
            }
        }

        private async Task<bool> PutContratoAsync(string webApi, Contratos contrato)
        {
            using (var client = new HttpClient())
            {
                var serializedContrato = JsonConvert.SerializeObject(contrato);
                var content = new StringContent(serializedContrato, Encoding.UTF8, "application/json");
                var result = await client.PutAsync(webApi + "PutContrato/" + contrato.idContrato, content);
                resultado = result.IsSuccessStatusCode;
                return resultado;
            }
        }

        public async Task<bool> DeleteContratoAsync(string webApi, int idContrato)
        {
            try
            {
                HttpClient client = new HttpClient();
                var result = await client.DeleteAsync(webApi + "DeleteContrato/" + idContrato);
                resultado = result.IsSuccessStatusCode;
                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string ValidarSalvar(Contratos contrato)
        {
            string validacao = string.Empty;

            if (string.IsNullOrEmpty(contrato.Numero))
            {
                validacao += "\r\nInforme o Número do contrato!";
            }

            return validacao;
        }

        public async Task<bool> SalvarContrato(string webApi, Contratos contrato)
        {
            try
            {
                string validacao = ValidarSalvar(contrato);
                if (string.IsNullOrEmpty(validacao))
                {
                    if (contrato.idContrato > 0)
                    {
                        resultado = await PutContratoAsync(webApi, contrato);
                        return resultado;
                    }
                    else
                    {
                        resultado = await PostContratoAsync(webApi, contrato);
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
