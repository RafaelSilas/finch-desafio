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
    public class BancoBLL
    {
        public List<Bancos> listaBancos = null;
        public Bancos banco = null;
        public bool resultado = false;
   
        public async Task<List<Bancos>> GetBancosAsync(string webApi)
        {
            try
            {
                HttpClient client = new HttpClient();
                var response = await client.GetStringAsync(webApi + "GetListaBancos");
                listaBancos = JsonConvert.DeserializeObject<List<Bancos>>(response);
                return listaBancos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Bancos> GetBancoAsync(string webApi, int bancoId)
        {
            try
            {
                HttpClient client = new HttpClient();
                var response = await client.GetStringAsync(webApi + "GetBanco/" + bancoId);
                banco = JsonConvert.DeserializeObject<Bancos>(response);
                return banco;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<bool> PostBancoAsync(string webApi, Bancos banco)
        {
            using (var client = new HttpClient())
            {
                var serializedBanco = JsonConvert.SerializeObject(banco);
                var content = new StringContent(serializedBanco, Encoding.UTF8, "application/json");
                var result = await client.PostAsync(webApi + "PostBanco", content);
                resultado = result.IsSuccessStatusCode;
                return resultado;
            }
        }

        private async Task<bool> PutBancoAsync(string webApi, Bancos banco)
        {
            using (var client = new HttpClient())
            {
                var serializedBanco = JsonConvert.SerializeObject(banco);
                var content = new StringContent(serializedBanco, Encoding.UTF8, "application/json");
                var result = await client.PutAsync(webApi + "PutBanco/" + banco.idBanco, content);
                resultado = result.IsSuccessStatusCode;
                return resultado;
            }
        }

        public async Task<bool> DeleteBancoAsync(string webApi, int bancoId)
        {
            try
            {
                HttpClient client = new HttpClient();
                var result = await client.DeleteAsync(webApi + "DeleteBanco/" + bancoId);
                resultado = result.IsSuccessStatusCode;
                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string ValidarSalvar(Bancos banco)
        {
            string validacao = string.Empty;

            if (banco.Codigo == 0)
            {
                validacao += "\r\nInforme o Código do Banco!";
            }

            if (string.IsNullOrEmpty(banco.Nome))
            {
                validacao += "\r\nInforme o Nome do Banco!";
            }

            return validacao;
        }

        public async Task<bool> SalvarBanco(string webApi, Bancos banco)
        {
            try
            {
                string validacao = ValidarSalvar(banco);
                if (string.IsNullOrEmpty(validacao))
                {
                    if (banco.idBanco > 0)
                    {
                        resultado = await PutBancoAsync(webApi, banco);
                        return resultado;
                    }
                    else
                    {
                        resultado = await PostBancoAsync(webApi, banco);
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
