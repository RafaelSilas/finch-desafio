using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.Dominio;
using EFCore.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCore.ProtestoAPI.Controllers
{
    [Route("protestowebapi")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private readonly IRepositorio _repo;
        public UsuarioController(IRepositorio repo)
        {
            _repo = repo;
        }

        [HttpGet("GetListaUsuarios", Name = "GetListaUsuarios")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var usuarios = await _repo.GetAllUsuarios();
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        [HttpGet("GetUsuario/{id}", Name = "GetUsuario")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var usuarios = await _repo.GetUsuariosId(id);
                if (usuarios != null)
                {
                    return Ok(usuarios);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
            return BadRequest("Usuario não encontrado!");
        }

        [HttpPost("PostUsuario", Name = "PostUsuario")]
        public async Task<IActionResult> Post(Usuarios model)
        {
            Usuarios usuarioCad = await _repo.LoginValido(model.login, model.Senha);
            if (usuarioCad != null)
            {
                if (usuarioCad.idUsuario > 0)
                {
                    return Ok(usuarioCad);
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut("PutUsuario/{id}", Name = "PutUsuario")]
        public async Task<ActionResult> Put(int id, Usuarios model)
        {
            if (model.idUsuario == 0)
                model.idUsuario = id;
            try
            {
                var usuarios = await _repo.GetUsuariosId(id);
                if (usuarios != null)
                {
                    _repo.Update(model);

                    if (await _repo.SaveChangeAsync())
                    {
                        return Ok("Usuario atualizado com sucesso!");
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
            return BadRequest("Usuario não encontrado!");
        }

        [HttpDelete("DeleteUsuario/{id}", Name = "DeleteUsuario")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var usuarios = await _repo.GetUsuariosId(id);
                if (usuarios != null)
                {
                    _repo.Delete(usuarios);
                    if (await _repo.SaveChangeAsync())
                    {
                        return Ok("Usuario excluído com sucesso!");
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
            return BadRequest("Usuario não encontrado!");
        }
    }
}