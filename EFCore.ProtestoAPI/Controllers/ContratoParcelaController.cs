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
    public class ContratoParcelaController : Controller
    {
        private readonly IRepositorio _repo;
        public ContratoParcelaController(IRepositorio repo)
        {
            _repo = repo;
        }

        [HttpGet("GetListaContratosParcelas", Name = "GetListaContratosParcelas")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var contratosparcelas = await _repo.GetAllContratosParcelas();
                return Ok(contratosparcelas);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        [HttpGet("GetContratoParcela/{id}", Name = "GetContratoParcela")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var contratosparcelas = await _repo.GetContratoParcelaId(id);
                if (contratosparcelas != null)
                {
                    return Ok(contratosparcelas);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
            return BadRequest("Contratos Parcelas não encontrado!");
        }

        [HttpPost("PostContratoParcela", Name = "PostContratoParcela")]
        public async Task<IActionResult> Post(ContratosParcelas model)
        {
            try
            {
                var contratosparcelas = await _repo.GetContratoParcelaId(model.idContratoParcela);

                if (contratosparcelas == null)
                {
                    _repo.Add(model);
                    if (await _repo.SaveChangeAsync())
                    {
                        return Ok("Contrato Parcela cadastrado com sucesso!");
                    }
                }
                else
                {
                    return BadRequest($"Erro: Esse Contrato Parcela já está cadastrado!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
            return BadRequest("Erro: Não Salvou!!");
        }

        [HttpPut("PutContratoParcela/{id}", Name = "PutContratoParcela")]
        public async Task<ActionResult> Put(int id, ContratosParcelas model)
        {
            if (model.idContratoParcela == 0)
                model.idContratoParcela = id;
            try
            {
                var contratosparcelas = await _repo.GetContratoParcelaId(id);
                if (contratosparcelas != null)
                {
                    _repo.Update(model);

                    if (await _repo.SaveChangeAsync())
                    {
                        return Ok("Contrato Parcela atualizado com sucesso!");
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
            return BadRequest("Contrato Parcela não encontrado!");
        }

        [HttpDelete("DeleteContratoParcela/{id}", Name = "DeleteContratoParcela")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var contratosparcelas = await _repo.GetContratoParcelaId(id);
                if (contratosparcelas != null)
                {
                    _repo.Delete(contratosparcelas);
                    if (await _repo.SaveChangeAsync())
                    {
                        return Ok("Contrato Parcela excluído com sucesso!");
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
            return BadRequest("Contrato Parcela não encontrado!");
        }
    }
}