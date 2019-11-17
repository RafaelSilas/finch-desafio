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
    public class CidadeController : Controller
    {
        private readonly IRepositorio _repo;
        public CidadeController(IRepositorio repo)
        {
            _repo = repo;
        }

        [HttpGet("GetListaCidades", Name = "GetListaCidades")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var cidades = await _repo.GetAllCidades();
                return Ok(cidades);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        [HttpGet("GetCidade/{id}", Name = "GetCidade")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var cidades = await _repo.GetCidadeID(id);
                if (cidades != null)
                {
                    return Ok(cidades);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
            return BadRequest("Cidade não encontrada!");
        }

        [HttpPost("PostCidade", Name = "PostCidade")]
        public async Task<IActionResult> Post(Cidades model)
        {
            try
            {
                var cidades = await _repo.GetCidadeID(model.idCidade);

                if (cidades == null)
                {
                    _repo.Add(model);
                    if (await _repo.SaveChangeAsync())
                    {
                        return Ok("Cidade cadastrada com sucesso!");
                    }
                }
                else
                {
                    return BadRequest($"Erro: Essa cidade já está cadastrado!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
            return BadRequest("Erro: Não Salvou!!");
        }

        [HttpPut("PutCidade/{id}", Name = "PutCidade")]
        public async Task<ActionResult> Put(int id, Cidades model)
        {
            if (model.idCidade == 0)
                model.idCidade = id;
            try
            {
                var cidades = await _repo.GetCidadeID(id);
                if (cidades != null)
                {
                    _repo.Update(model);

                    if (await _repo.SaveChangeAsync())
                    {
                        return Ok("Cidade atualizada com sucesso!");
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
            return BadRequest("Cidade não encontrada!");
        }

        [HttpDelete("DeleteCidade/{id}", Name = "DeleteCidade")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var cidades = await _repo.GetCidadeID(id);
                if (cidades != null)
                {
                    _repo.Delete(cidades);
                    if (await _repo.SaveChangeAsync())
                    {
                        return Ok("Cidade excluída com sucesso!");
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
            return BadRequest("Cidades não encontrada!");
        }
    }
}