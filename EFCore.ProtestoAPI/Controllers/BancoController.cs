using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.Dominio;
using EFCore.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EFCore.ProtestoAPI.Controllers
{
    [Route("protestowebapi")]
    [ApiController]
    public class BancoController : ControllerBase
    {
        private readonly IRepositorio _repo;
        public BancoController(IRepositorio repo)
        {
            _repo = repo;
        }

        [HttpGet("GetListaBancos", Name = "GetListaBancos")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var bancos = await _repo.GetAllBancos();
                return Ok(bancos);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        [HttpGet("GetBanco/{id}", Name = "GetBanco")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var banco = await _repo.GetBancoId(id);
                if (banco != null)
                {
                    return Ok(banco);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
            return BadRequest("banco não encontrado!");
        }

        [HttpPost("PostBanco", Name = "PostBanco")]
        public async Task<IActionResult> Post(Bancos model)
        {
            try
            {
                var banco = await _repo.GetBancoNome(model.Nome);

                if (banco == null)
                {
                    _repo.Add(model);
                    if (await _repo.SaveChangeAsync())
                    {
                        return Ok("Banco cadastrado com sucesso!");
                    }
                }
                else
                {
                    return BadRequest($"Erro: Esse banco já está cadastrado!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
            return BadRequest("Erro: Não Salvou!!");
        }

        [HttpPut("PutBanco/{id}", Name = "PutBanco")]
        public async Task<ActionResult> Put(int id, Bancos model)
        {
            if (model.idBanco == 0)
                model.idBanco = id;
            try
            {
                var banco = await _repo.GetBancoId(id);
                if (banco != null)
                {
                    _repo.Update(model);

                    if (await _repo.SaveChangeAsync())
                    {
                        return Ok("banco atualizado com sucesso!");
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
            return BadRequest("Banco não encontrado!");
        }

        [HttpDelete("DeleteBanco/{id}", Name = "DeleteBanco")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var banco = await _repo.GetBancoId(id);
                if (banco != null)
                {
                    _repo.Delete(banco);
                    if (await _repo.SaveChangeAsync())
                    {
                        return Ok("Banco excluído com sucesso!");
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
            return BadRequest("Banco não encontrado!");
        }
    }
}
