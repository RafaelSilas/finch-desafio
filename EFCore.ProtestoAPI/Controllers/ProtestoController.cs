using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.Repositorio;
using EFCore.Dominio;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EFCore.ProtestoAPI.Controllers
{
   
        [Route("protestowebapi")]
        [ApiController]
        public class ProtestoController : ControllerBase
        {
            private readonly IRepositorio _repo;
            public ProtestoController(IRepositorio repo)
            {
                _repo = repo;
            }

            [HttpGet("GetListaProtestos", Name = "GetListaProtestos")]
            public async Task<IActionResult> Get()
            {
                try
                {
                    var Protestos = await _repo.GetAllProtestos();
                    return Ok(Protestos);
                }
                catch (Exception ex)
                {
                    return BadRequest($"Erro: {ex}");
                }
            }

            [HttpGet("GetProtesto/{id}", Name = "GetProtesto")]
            public async Task<IActionResult> Get(int id)
            {
                try
                {
                    var Protesto = await _repo.GetProtestoId(id);
                    if (Protesto != null)
                    {
                        return Ok(Protesto);
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest($"Erro: {ex}");
                }
                return BadRequest("Protesto não encontrado!");
            }

        [HttpGet("GetProtestoContrato/{id}", Name = "GetProtestoContrato")]
        public async Task<IActionResult> GetProtestoContrato(int id)
        {
            try
            {
                var Protesto = await _repo.GetProtestoContrato(id);
                if (Protesto != null)
                {
                    return Ok(Protesto);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
            return BadRequest("Protesto não encontrado!");
        }

        [HttpPost("PostProtesto", Name = "PostProtesto")]
            public async Task<IActionResult> Post(Protestos model)
            {
                try
                {
                    var Protesto = await _repo.GetProtestoId(model.idProtesto);

                    if (Protesto == null)
                    {
                        _repo.Add(model);
                        if (await _repo.SaveChangeAsync())
                        {
                            return Ok("Protesto cadastrado com sucesso!");
                        }
                    }
                    else
                    {
                        return BadRequest($"Erro: Esse Protesto já está cadastrado!");
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest($"Erro: {ex}");
                }
                return BadRequest("Erro: Não Salvou!!");
            }

            [HttpPut("PutProtesto/{id}", Name = "PutProtesto")]
            public async Task<ActionResult> Put(int id, Protestos model)
            {
                if (model.idProtesto == 0)
                    model.idProtesto = id;
                try
                {
                    var Protesto = await _repo.GetProtestoId(id);
                    if (Protesto != null)
                    {
                        _repo.Update(model);

                        if (await _repo.SaveChangeAsync())
                        {
                            return Ok("Protesto atualizado com sucesso!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest($"Erro: {ex}");
                }
                return BadRequest("Protesto não encontrado!");
            }

            [HttpDelete("DeleteProtesto/{id}", Name = "DeleteProtesto")]
            public async Task<IActionResult> Delete(int id)
            {
                try
                {
                    var Protesto = await _repo.GetProtestoId(id);
                    if (Protesto != null)
                    {
                        _repo.Delete(Protesto);
                        if (await _repo.SaveChangeAsync())
                        {
                            return Ok("Protesto excluído com sucesso!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest($"Erro: {ex}");
                }
                return BadRequest("Protesto não encontrado!");
            }
        }
}
