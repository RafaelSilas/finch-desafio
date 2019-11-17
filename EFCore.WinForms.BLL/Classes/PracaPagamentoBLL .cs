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
    public class PracaPagamentoBLL
    {
        public List<PracasPagamentos> listaPracasPagamentos = null;
        public PracasPagamentos pracaPagamento = null;
        public bool resultado = false;

        public async Task<List<PracasPagamentos>> GetPracasPagamentosAsync(string webApi)
        {
            try
            {
                HttpClient client = new HttpClient();
                var response = await client.GetStringAsync(webApi + "GetListaPracasPagamentos");
                listaPracasPagamentos = JsonConvert.DeserializeObject<List<PracasPagamentos>>(response);
                return listaPracasPagamentos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PracasPagamentos> GetPracaPagamentoAsync(string webApi, int idPracaPagamento)
        {
            try
            {
                HttpClient client = new HttpClient();
                var response = await client.GetStringAsync(webApi + "GetPracaPagamento/" + idPracaPagamento);
                pracaPagamento = JsonConvert.DeserializeObject<PracasPagamentos>(response);
                return pracaPagamento;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<bool> PostPracaPagamentoAsync(string webApi, PracasPagamentos pracaPagamento)
        {
            using (var client = new HttpClient())
            {
                var serializedPracaPagamento = JsonConvert.SerializeObject(pracaPagamento);
                var content = new StringContent(serializedPracaPagamento, Encoding.UTF8, "application/json");
                var result = await client.PostAsync(webApi + "PostPracaPagamento", content);
                resultado = result.IsSuccessStatusCode;
                return resultado;
            }
        }

        private async Task<bool> PutPracaPagamentoAsync(string webApi, PracasPagamentos pracaPagamento)
        {
            using (var client = new HttpClient())
            {
                var serializedBanco = JsonConvert.SerializeObject(pracaPagamento);
                var content = new StringContent(serializedBanco, Encoding.UTF8, "application/json");
                var result = await client.PutAsync(webApi + "PutPracaPagamento/" + pracaPagamento.idPracaPagamento, content);
                resultado = result.IsSuccessStatusCode;
                return resultado;
            }
        }

        public async Task<bool> DeletePracaPagamentoAsync(string webApi, int idPracaPagamento)
        {
            try
            {
                HttpClient client = new HttpClient();
                var result = await client.DeleteAsync(webApi + "DeletePracaPagamento/" + idPracaPagamento);
                resultado = result.IsSuccessStatusCode;
                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string ValidarSalvar(PracasPagamentos pracaPagemento)
        {
            string validacao = string.Empty;

            return validacao;
        }

        public async Task<bool> SalvarPracaPagamento(string webApi, PracasPagamentos pracaPagamento)
        {
            try
            {
                string validacao = ValidarSalvar(pracaPagamento);
                if (string.IsNullOrEmpty(validacao))
                {
                    if (pracaPagamento.idPracaPagamento > 0)
                    {
                        resultado = await PutPracaPagamentoAsync(webApi, pracaPagamento);
                        return resultado;
                    }
                    else
                    {
                        resultado = await PostPracaPagamentoAsync(webApi, pracaPagamento);
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
