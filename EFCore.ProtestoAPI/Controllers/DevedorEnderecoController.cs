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
    public class DevedorEnderecoController : Controller
    {
        private readonly IRepositorio _repo;
        public DevedorEnderecoController(IRepositorio repo)
        {
            _repo = repo;
        }

        [HttpGet("GetListaDevedoresEnderecos", Name = "GetListaDevedoresEnderecos")]
        public async Task<IActionResult> Get()
        {
          try
            {
                var devedoresEnderecos = await _repo.GetAllDevedoresEnderecos();
                return Ok(devedoresEnderecos);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        [HttpGet("GetDevedorEndereco/{id}", Name = "GetDevedorEndereco")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var devedoresEnderecos = await _repo.GetDevedoresEnderecosId(id);
                if (devedoresEnderecos != null)
                {
                    return Ok(devedoresEnderecos);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
            return BadRequest("Devedor Endereco não encontrado!");
        }

        [HttpPost("PostDevedorEndereco", Name = "PostDevedorEndereco")]
        public async Task<IActionResult> Post(DevedoresEnderecos model)
        {
            try
            {
                var devedoresEnderecos = await _repo.GetDevedoresEnderecosCEP(model.CEP);
                
                if (devedoresEnderecos == null)
                {
                    _repo.Add(model);
                    if (await _repo.SaveChangeAsync())
                    {
                        return Ok("Devedor Endereco cadastrado com sucesso!");
                    }
                }
                else
                {
                    return BadRequest($"Erro: Esse Devedor Endereco já está cadastrado!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
            return BadRequest("Erro: Não Salvou!!");
        }

        [HttpPut("PutDevedorEndereco/{id}", Name = "PutDevedorEndereco")]
        public async Task<ActionResult> Put(int id, DevedoresEnderecos model)
        {
            if (model.idDevedorEndereco == 0)
                model.idDevedorEndereco = id;
            try
            {
                var devedoresEnderecos = await _repo.GetDevedoresEnderecosId(id);
                if (devedoresEnderecos != null)
                {
                    _repo.Update(model);

                    if (await _repo.SaveChangeAsync())
                    {
                        return Ok("Devedor Endereco atualizado com sucesso!");
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
            return BadRequest("Devedor Endereco não encontrado!");
        }

        [HttpDelete("DeleteContrato/{id}", Name = "DeleteContrato")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var devedoresEnderecos = await _repo.GetDevedoresEnderecosId(id);
                if (devedoresEnderecos != null)
                {
                    _repo.Delete(devedoresEnderecos);
                    if (await _repo.SaveChangeAsync())
                    {
                        return Ok("Devedor Endereco excluído com sucesso!");
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
            return BadRequest("Devedor Endereco não encontrado!");
        }
    }
}