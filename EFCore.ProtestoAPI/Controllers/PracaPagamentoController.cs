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
    public class PracaPagamentoController : Controller
    {
        private readonly IRepositorio _repo;
        public PracaPagamentoController(IRepositorio repo)
        {
            _repo = repo;
        }

        [HttpGet("GetListaPracasPagamentos", Name = "GetListaPracasPagamentos")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var pracaspagamentos = await _repo.GetAllPracasPagamentos();
                return Ok(pracaspagamentos);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        [HttpGet("GetPracaPagamento/{id}", Name = "GetPracaPagamento")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var pracaspagamentos = await _repo.GetPracasPagamentoId(id);
                if (pracaspagamentos != null)
                {
                    return Ok(pracaspagamentos);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
            return BadRequest("Protesto não encontrado!");
        }

        [HttpPost("PostPracaPagamento", Name = "PostPracaPagamento")]
        public async Task<IActionResult> Post(PracasPagamentos model)
        {
            try
            {
                var pracaspagamentos = await _repo.GetPracasPagamentoId(model.idPracaPagamento);

                if (pracaspagamentos == null)
                {
                    _repo.Add(model);
                    if (await _repo.SaveChangeAsync())
                    {
                        return Ok("Praca de Pagamento cadastrada com sucesso!");
                    }
                }
                else
                {
                    return BadRequest($"Erro: Esse Praca de Pagamento já está cadastrada!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
            return BadRequest("Erro: Não Salvou!!");
        }

        [HttpPut("PutPracaPagamento/{id}", Name = "PutPracaPagamento")]
        public async Task<ActionResult> Put(int id, PracasPagamentos model)
        {
            if (model.idPracaPagamento == 0)
                model.idPracaPagamento = id;
            try
            {
                var pracaspagamentos = await _repo.GetPracasPagamentoId(id);
                if (pracaspagamentos != null)
                {
                    _repo.Update(model);

                    if (await _repo.SaveChangeAsync())
                    {
                        return Ok("Praca de Pagamento  atualizada com sucesso!");
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
            return BadRequest("Praca de Pagamento não encontrada!");
        }

        [HttpDelete("DeletePracaPagamento/{id}", Name = "DeletePracaPagamento")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var pracaspagamentos = await _repo.GetPracasPagamentoId(id);
                if (pracaspagamentos != null)
                {
                    _repo.Delete(pracaspagamentos);
                    if (await _repo.SaveChangeAsync())
                    {
                        return Ok("Praca de Pagamento excluída com sucesso!");
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
            return BadRequest("Praca de Pagamento não encontrada!");
        }
    }
}