using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using EFCore.Dominio;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace EFCore.WinForms.BLL
{
    public class UsuarioBLL
    {
        public List<Usuarios> listaUsuarios = null;
        public Usuarios usuario = null;
        public bool resultado = false;

        public async Task<List<Usuarios>> GetUsuariosAsync(string webApi)
        {
            try
            {
                HttpClient client = new HttpClient();
                var response = await client.GetStringAsync(webApi + "usuario");
                listaUsuarios = JsonConvert.DeserializeObject<List<Usuarios>>(response);
                return listaUsuarios;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Usuarios> GetUsuarioAsync(string webApi, int usuarioId)
        {
            try
            {
                HttpClient client = new HttpClient();
                var response = await client.GetStringAsync(webApi + "GetUsuario/" + usuarioId);
                usuario = JsonConvert.DeserializeObject<Usuarios>(response);
                return usuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<bool> PostUsuarioAsync(string webApi, Usuarios usuario)
        {
            using (var client = new HttpClient())
            {
                var serializedUsuario = JsonConvert.SerializeObject(usuario);
                var content = new StringContent(serializedUsuario, Encoding.UTF8, "application/json");
                var result = await client.PostAsync(webApi + "PostUsuario", content);
                resultado = result.IsSuccessStatusCode;
                return resultado;
            }           
        }

        private async Task<bool> PutUsuarioAsync(string webApi, Usuarios usuario)
        {
            using (var client = new HttpClient())
            {
                var serializedUsuario = JsonConvert.SerializeObject(usuario);
                var content = new StringContent(serializedUsuario, Encoding.UTF8, "application/json");
                var result = await client.PutAsync(webApi + "PutUsuario/" + usuario.idUsuario, content);
                resultado = result.IsSuccessStatusCode;
                return resultado;
            }
        }

        public async Task<bool> DeleteUsuarioAsync(string webApi, int usuarioId)
        {
            try
            {
                HttpClient client = new HttpClient();
                var result = await client.DeleteAsync(webApi + "DeleteUsuario/" + usuarioId);
                resultado = result.IsSuccessStatusCode;
                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string ValidarLogin(Usuarios usuario)
        {
            string validacao = string.Empty;

            if (string.IsNullOrEmpty(usuario.login))
            {
                validacao += "\r\nInforme o Login!";
            }

            if (string.IsNullOrEmpty(usuario.Senha))
            {
                validacao += "\r\nInforme a Senha!";
            }

            return validacao;
        }
        public async Task<bool> EfetuarLogin(string webApi, Usuarios usuario)
        {
            try
            {
                 resultado = await PostUsuarioAsync(webApi, usuario);
                 return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
