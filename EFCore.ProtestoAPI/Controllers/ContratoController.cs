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
    public class ContratoController : Controller
    {
        private readonly IRepositorio _repo;
        public ContratoController(IRepositorio repo)
        {
            _repo = repo;
        }

        [HttpGet("GetListaContratos", Name = "GetListaContratos")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var contratos = await _repo.GetAllContratos();
                return Ok(contratos);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        [HttpGet("GetContrato/{id}", Name = "GetContrato")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var contratos = await _repo.GetContratoId(id);
                if (contratos != null)
                {
                    return Ok(contratos);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
            return BadRequest("Contrato não encontrado!");
        }

        [HttpPost("PostContrato", Name = "PostContrato")]
        public async Task<IActionResult> Post(Contratos model)
        {
            try
            {
                var contratos = await _repo.GetContratoId(model.idContrato);

                if (contratos == null)
                {
                    _repo.Add(model);
                    if (await _repo.SaveChangeAsync())
                    {
                        return Ok("Contrato cadastrado com sucesso!");
                    }
                }
                else
                {
                    return BadRequest($"Erro: Esse Contrato já está cadastrado!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
            return BadRequest("Erro: Não Salvou!!");
        }

        [HttpPut("PutContrato/{id}", Name = "PutContrato")]
        public async Task<ActionResult> Put(int id, Contratos model)
        {
            if (model.idContrato == 0)
                model.idContrato = id;
            try
            {
                var contratos = await _repo.GetContratoId(id);
                if (contratos != null)
                {
                    _repo.Update(model);

                    if (await _repo.SaveChangeAsync())
                    {
                        return Ok("Contrato atualizado com sucesso!");
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
            return BadRequest("Contrato não encontrado!");
        }

        [HttpDelete("DeleteContrato/{id}", Name = "DeleteContrato")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var contratos = await _repo.GetContratoId(id);
                if (contratos != null)
                {
                    _repo.Delete(contratos);
                    if (await _repo.SaveChangeAsync())
                    {
                        return Ok("Contrato excluído com sucesso!");
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
            return BadRequest("Contrato não encontrado!");
        }
    }
}