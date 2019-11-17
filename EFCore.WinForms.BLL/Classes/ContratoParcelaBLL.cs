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
    public class ContratoParcelaBLL
    {
        public List<ContratosParcelas> listaContratosParcelas = null;
        public ContratosParcelas contratosParcelas = null;
        public bool resultado = false;

        public async Task<List<ContratosParcelas>> GetContratosParcelasAsync(string webApi)
        {
            try
            {
                HttpClient client = new HttpClient();
                var response = await client.GetStringAsync(webApi + "GetListaContratosParcelas");
                listaContratosParcelas = JsonConvert.DeserializeObject<List<ContratosParcelas>>(response);
                return listaContratosParcelas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ContratosParcelas> GetContratosParcelasAsync(string webApi, int idContratoParcela)
        {
            try
            {
                HttpClient client = new HttpClient();
                var response = await client.GetStringAsync(webApi + "GetContratoParcela/" + idContratoParcela);
                contratosParcelas = JsonConvert.DeserializeObject<ContratosParcelas>(response);
                return contratosParcelas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<bool> PostContratoParcelaAsync(string webApi, ContratosParcelas contratoParcela)
        {
            using (var client = new HttpClient())
            {
                var serializedContratoParcela = JsonConvert.SerializeObject(contratoParcela);
                var content = new StringContent(serializedContratoParcela, Encoding.UTF8, "application/json");
                var result = await client.PostAsync(webApi + "PostContratoParcela", content);
                resultado = result.IsSuccessStatusCode;
                return resultado;
            }
        }

        private async Task<bool> PutContratoParcelaAsync(string webApi, ContratosParcelas contratoParcela)
        {
            using (var client = new HttpClient())
            {
                var serializedContratoParcela = JsonConvert.SerializeObject(contratoParcela);
                var content = new StringContent(serializedContratoParcela, Encoding.UTF8, "application/json");
                var result = await client.PutAsync(webApi + "PutContratoParcela/" + contratoParcela.idContratoParcela, content);
                resultado = result.IsSuccessStatusCode;
                return resultado;
            }
        }

        public async Task<bool> DeleteBancoAsync(string webApi, int idContratoParcela)
        {
            try
            {
                HttpClient client = new HttpClient();
                var result = await client.DeleteAsync(webApi + "DeleteContratoParcela/" + idContratoParcela);
                resultado = result.IsSuccessStatusCode;
                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string ValidarSalvar(ContratosParcelas contratoParcela)
        {
            string validacao = string.Empty;

            return validacao;
        }

        public async Task<bool> SalvarContratoParcela(string webApi, ContratosParcelas contratoParcela)
        {
            try
            {
                string validacao = ValidarSalvar(contratoParcela);
                if (string.IsNullOrEmpty(validacao))
                {
                    if (contratoParcela.idContratoParcela > 0)
                    {
                        resultado = await PutContratoParcelaAsync(webApi, contratoParcela);
                        return resultado;
                    }
                    else
                    {
                        resultado = await PostContratoParcelaAsync(webApi, contratoParcela);
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
