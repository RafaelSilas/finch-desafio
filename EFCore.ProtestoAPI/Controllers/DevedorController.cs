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
    public class DevedorController : Controller
    {
        public int  idDevedorCadastrado = 0;
        private readonly IRepositorio _repo;
        public DevedorController(IRepositorio repo)
        {
            _repo = repo;
        }

        [HttpGet("GetListaDevedores", Name = "GetListaDevedores")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var devedores = await _repo.GetAllDevedores();
                return Ok(devedores);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        [HttpGet("GetDevedor/{id}", Name = "GetDevedor")]
        public async Task<ActionResult<Devedores>> GetDevedor(int id)
        {
            try
            {
                var devedores = await _repo.GetDevedorId(id);
                if (devedores != null)
                {
                    return devedores;
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
            return BadRequest("Devedor não encontrado!");
        }

        [HttpPost("PostDevedor", Name = "PostDevedor")]
        public async Task<IActionResult> Post(Devedores model)
        {
            try
            {
                var devedor = await _repo.GetDevedorCPF_CNPJ(model.CPF_CNPJ);

                if (devedor == null)
                {
                    _repo.Add(model);
                    if (await _repo.SaveChangeAsync())
                    {
                        return Ok("Devedor cadastrado com sucesso!");
                    }
                }
                else
                {
                    return BadRequest($"Erro: Esse devedor já está cadastrado!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
            return BadRequest("Erro: Não Salvou!!");
        }

        [HttpPut("PutDevedor/{id}", Name = "PutDevedor")]
        public async Task<ActionResult> Put(int id, Devedores model)
        {
            if (model.idDevedor == 0)
                model.idDevedor = id;
            try
            {
                var devedores = await _repo.GetDevedorId(id);
                if (devedores != null)
                {
                    _repo.Update(model);

                    if (await _repo.SaveChangeAsync())
                    {
                        return Ok("Devedor atualizado com sucesso!");
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
            return BadRequest("Devedor não encontrado!");
        }

        [HttpDelete("DeleteDevedor/{id}", Name = "DeleteDevedor")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var devedores = await _repo.GetDevedorId(id);
                if (devedores != null)
                {
                    _repo.Delete(devedores);
                    if (await _repo.SaveChangeAsync())
                    {
                        return Ok("Devedor excluído com sucesso!");
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
            return BadRequest("Devedor não encontrado!");
        }
    }
}