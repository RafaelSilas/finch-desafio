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
    public class CidadeBLL
    {
        public List<Cidades> listaCidades = null;
        public Cidades cidade = null;
        public bool resultado = false;

        public async Task<List<Cidades>> GetCidadesAsync(string webApi)
        {
            try
            {
                HttpClient client = new HttpClient();
                var response = await client.GetStringAsync(webApi + "GetListaCidades");
                listaCidades = JsonConvert.DeserializeObject<List<Cidades>>(response);
                return listaCidades;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Cidades> GetCidadeAsync(string webApi, int idBanco)
        {
            try
            {
                HttpClient client = new HttpClient();
                var response = await client.GetStringAsync(webApi + "GetCidade/" + idBanco);
                cidade = JsonConvert.DeserializeObject<Cidades>(response);
                return cidade;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<bool> PostCidadeAsync(string webApi, Cidades cidade)
        {
            using (var client = new HttpClient())
            {
                var serializedBanco = JsonConvert.SerializeObject(cidade);
                var content = new StringContent(serializedBanco, Encoding.UTF8, "application/json");
                var result = await client.PostAsync(webApi + "PostCidade", content);
                resultado = result.IsSuccessStatusCode;
                return resultado;
            }
        }

        private async Task<bool> PutCidadeAsync(string webApi, Cidades cidade)
        {
            using (var client = new HttpClient())
            {
                var serializedCidade = JsonConvert.SerializeObject(cidade);
                var content = new StringContent(serializedCidade, Encoding.UTF8, "application/json");
                var result = await client.PutAsync(webApi + "PutCidade/" + cidade.idCidade, content);
                resultado = result.IsSuccessStatusCode;
                return resultado;
            }
        }

        public async Task<bool> DeleteCidadeAsync(string webApi, int idCidade)
        {
            try
            {
                HttpClient client = new HttpClient();
                var result = await client.DeleteAsync(webApi + "DeleteCidade/" + idCidade);
                resultado = result.IsSuccessStatusCode;
                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string ValidarSalvar(Cidades cidade)
        {
            string validacao = string.Empty;

            if (string.IsNullOrEmpty(cidade.Descricao))
            {
                validacao += "\r\nInforme a descrição da cidade!";
            }

            return validacao;
        }

        public async Task<bool> SalvarCidade(string webApi, Cidades cidade)
        {
            try
            {
                string validacao = ValidarSalvar(cidade);
                if (string.IsNullOrEmpty(validacao))
                {
                    if (cidade.idCidade > 0)
                    {
                        resultado = await PutCidadeAsync(webApi, cidade);
                        return resultado;
                    }
                    else
                    {
                        resultado = await PostCidadeAsync(webApi, cidade);
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
