using Business.Interfaces.Notification;
using Business.Interfaces.Services;
using Business.ViewModels.Leiturista;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize]
    public class LeituristaController : NotificadorController
    {
        private readonly ILeituristaService _leituristaService;
        private readonly INotificador _notificador;

        public LeituristaController(ILeituristaService leituristaService, INotificador notificador) : base(notificador)
        {
            _leituristaService = leituristaService;
            _notificador = notificador;
        }

        [HttpGet]
        [Route("buscar-todos")]
        public async Task<IActionResult> BuscarTodos()
        {
            try
            {
                return Ok(await _leituristaService.BuscarTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("buscar-por-id/{id:long}")]
        public async Task<IActionResult> BuscarPorId(long id)
        {
            try
            {
                return RespostaCustomizada(await _leituristaService.BuscarPorId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("buscar-por-matricula/{matricula:long}")]
        public async Task<IActionResult> BuscarPorMatricula(long matricula)
        {
            try
            {
                return RespostaCustomizada(await _leituristaService.BuscarPorMatricula(matricula));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("buscar-por-nome/{nome}")]
        public async Task<IActionResult> BuscarPorNome(string nome)
        {
            try
            {
                return RespostaCustomizada(await _leituristaService.BuscarPorNome(nome));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("buscar-por-ativo-inativo/{status}")]
        public async Task<IActionResult> BuscarPorStatusAtivoInativo(bool status)
        {
            try
            {
                return RespostaCustomizada(await _leituristaService.BuscarPorStatusAtivoOuInativo(status));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("cadastrar")]
        [Authorize(Roles = "Gerente")]
        public async Task<IActionResult> Cadastrar(CriaLeituristaViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return RespostaCustomizada();
                }

                if(await _leituristaService.Cadastrar(model))
                {
                    return Ok("cadastrado com sucesso");
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
        public async Task<IActionResult> Atualizar(CriaLeituristaViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return RespostaCustomizada();
                }
                if (await _leituristaService.Atualizar(model))
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
        [Route("deletar/{matricula:long}")]
        [Authorize(Roles = "Gerente")]
        public async Task<IActionResult> Deletar(long matricula)
        {
            try
            {
                if (await _leituristaService.Deletar(matricula))
                {
                    return Ok("Deletado com sucesso");
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
