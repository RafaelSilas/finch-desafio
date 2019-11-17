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
    public class DevedorEnderecoBLL
    {
        public List<DevedoresEnderecos> listaDevedoresEnderecos = null;
        public DevedoresEnderecos devedorEndereco = null;
        public bool resultado = false;

        public async Task<List<DevedoresEnderecos>> GetDevedoresEnderecosAsync(string webApi)
        {
            try
            {
                HttpClient client = new HttpClient();
                var response = await client.GetStringAsync(webApi + "GetListaDevedoresEnderecos");
                listaDevedoresEnderecos = JsonConvert.DeserializeObject<List<DevedoresEnderecos>>(response);
                return listaDevedoresEnderecos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DevedoresEnderecos> GetDevedorEnderecoAsync(string webApi, int idDevedorEndereco)
        {
            try
            {
                HttpClient client = new HttpClient();
                var response = await client.GetStringAsync(webApi + "GetDevedorEndereco/" + idDevedorEndereco);
                devedorEndereco = JsonConvert.DeserializeObject<DevedoresEnderecos>(response);
                return devedorEndereco;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<bool> PostDevedorEnderecoAsync(string webApi, DevedoresEnderecos devedorEndereco)
        {
            using (var client = new HttpClient())
            {
                var serializedDevedorEndereco = JsonConvert.SerializeObject(devedorEndereco);
                var content = new StringContent(serializedDevedorEndereco, Encoding.UTF8, "application/json");
                var result = await client.PostAsync(webApi + "PostDevedorEndereco", content);
                resultado = result.IsSuccessStatusCode;
                return resultado;
            }
        }

        private async Task<bool> PutDevedorEnderecoAsync(string webApi, DevedoresEnderecos devedorEndereco)
        {
            using (var client = new HttpClient())
            {
                var serializedDevedorEndereco = JsonConvert.SerializeObject(devedorEndereco);
                var content = new StringContent(serializedDevedorEndereco, Encoding.UTF8, "application/json");
                var result = await client.PutAsync(webApi + "PutDevedorEndereco/" + devedorEndereco.idDevedorEndereco, content);
                resultado = result.IsSuccessStatusCode;
                return resultado;
            }
        }

        public async Task<bool> DeleteDevedorEnderecoAsync(string webApi, int idDevedorEndereco)
        {
            try
            {
                HttpClient client = new HttpClient();
                var result = await client.DeleteAsync(webApi + "DeleteDevedorEndereco/" + idDevedorEndereco);
                resultado = result.IsSuccessStatusCode;
                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string ValidarSalvar(DevedoresEnderecos devedorEndereco)
        {
            string validacao = string.Empty;

            if (string.IsNullOrEmpty(devedorEndereco.Endereco))
            {
                validacao += "\r\nInforme o o Endereço!";
            }

            return validacao;
        }

        public async Task<bool> SalvarDevedorEndereco(string webApi, DevedoresEnderecos devedorEndereco)
        {
            try
            {
                string validacao = ValidarSalvar(devedorEndereco);
                if (string.IsNullOrEmpty(validacao))
                {
                    if (devedorEndereco.idDevedorEndereco > 0)
                    {
                        resultado = await PutDevedorEnderecoAsync(webApi, devedorEndereco);
                        return resultado;
                    }
                    else
                    {
                        resultado = await PostDevedorEnderecoAsync(webApi, devedorEndereco);
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
