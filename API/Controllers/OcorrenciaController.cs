using Business.Interfaces.Notification;
using Business.Interfaces.Services;
using Business.ViewModels.Ocorrencia;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize]
    public class OcorrenciaController : NotificadorController
    {
        private readonly IOcorrenciaService _ocorrenciaService;
        private readonly INotificador _notificador;

        public OcorrenciaController(IOcorrenciaService ocorrenciaService, INotificador notificador) : base(notificador)
        {
            _ocorrenciaService = ocorrenciaService;
            _notificador = notificador;
        }

        [HttpGet]
        [Route("buscar-todos")]
        public async Task<IActionResult> BuscarTodos()
        {
            try
            {
                return Ok(await _ocorrenciaService.BuscarTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("buscar-por-id/{id}")]
        public async Task<IActionResult> BuscarPorId(long id)
        {
            try
            {
                return RespostaCustomizada(await _ocorrenciaService.BuscarPorId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("buscar-por-ocorrencia/{descricao}")]
        public async Task<IActionResult> BuscarPorDescricao(string descricao)
        {
            try
            {
                return RespostaCustomizada(await _ocorrenciaService.BuscarPorDescricao(descricao));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("cadastrar")]
        [Authorize(Roles = "Gerente")]
        public async Task<IActionResult> Cadastrar(CriarOcorrenciaViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return RespostaCustomizada();
                }
                
                if(await _ocorrenciaService.Cadastrar(model))
                {
                    return Ok("Cadastrado com sucesso");
                }

                return RespostaCustomizada(model);
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("atualizar")]
        [Authorize(Roles = "Gerente")]
        public async Task<IActionResult> Atualizar(ExibirOcorrenciaViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return RespostaCustomizada();
                }
                if(await _ocorrenciaService.Atualizar(model))
                {
                    return Ok("Atualizado com sucesso");
                }

                return RespostaCustomizada(model);
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("deletar/{id:long}")]
        [Authorize(Roles = "Gerente")]
        public async Task<IActionResult> Deletar(long id)
        {
            try
            {
                if(await _ocorrenciaService.Deletar(id))
                {
                    return Ok();
                }

                return RespostaCustomizada();
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
