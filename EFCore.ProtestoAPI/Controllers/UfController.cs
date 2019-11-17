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
    public class UfController : Controller
    {
        private readonly IRepositorio _repo;
        public UfController(IRepositorio repo)
        {
            _repo = repo;
        }

        [HttpGet("GetListaUfs", Name = "GetListaUfs")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var ufs = await _repo.GetAllUfs();
                return Ok(ufs);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        [HttpGet("GetUf/{id}", Name = "GetUf")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var ufs = await _repo.GetUfId(id);
                if (ufs != null)
                {
                    return Ok(ufs);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
            return BadRequest("Uf não encontrado!");
        }

        [HttpPost("PostUf", Name = "PostUf")]
        public async Task<IActionResult> Post(UFs model)
        {
            try
            {
                var ufs = await _repo.GetUfId(model.idUf);

                if (ufs == null)
                {
                    _repo.Add(model);
                    if (await _repo.SaveChangeAsync())
                    {
                        return Ok("Uf cadastrado com sucesso!");
                    }
                }
                else
                {
                    return BadRequest($"Erro: Essa Ufs já está cadastrada!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
            return BadRequest("Erro: Não Salvou!!");
        }

        [HttpPut("PutUf/{id}", Name = "PutUf")]
        public async Task<ActionResult> Put(int id, UFs model)
        {
            if (model.idUf == 0)
                model.idUf = id;
            try
            {
                var ufs = await _repo.GetUfId(id);
                if (ufs != null)
                {
                    _repo.Update(model);

                    if (await _repo.SaveChangeAsync())
                    {
                        return Ok("Uf atualizada com sucesso!");
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
            return BadRequest("Contrato não encontrado!");
        }

        [HttpDelete("DeleteUf/{id}", Name = "DeleteUf")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var ufs = await _repo.GetUfId(id);
                if (ufs != null)
                {
                    _repo.Delete(ufs);
                    if (await _repo.SaveChangeAsync())
                    {
                        return Ok("Uf excluído com sucesso!");
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
            return BadRequest("Uf não encontrado!");
        }
    }
}