using Business.Interfaces.Notification;
using Business.Interfaces.Services;
using Business.ViewModels.Usuario;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize]
    public class UsuarioController : NotificadorController
    {
        private readonly IUsuarioService _usuarioService;
        private readonly INotificador _notificador;

        public UsuarioController(IUsuarioService usuarioService, INotificador notificador) : base(notificador)
        {
            _usuarioService = usuarioService;
            _notificador = notificador;
        }

        [HttpGet]
        [Route("buscar-todos")]
        public async Task<IActionResult> BuscarTodos()
        {
            try
            {
                return Ok(await _usuarioService.BuscarTodos());
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
                return RespostaCustomizada(await _usuarioService.BuscarPorId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPost]
        [Route("cadastrar")]
        [Authorize(Roles = "Gerente")]
        public async Task<IActionResult> Cadastrar(CriarUsuarioViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return RespostaCustomizada();
                }
                
                if(await _usuarioService.Cadastrar(model))
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
        public async Task<IActionResult> Atualizar(EditarUsuarioViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return RespostaCustomizada();
                }
                if (await _usuarioService.Atualizar(model))
                {
                    return Ok("Atualizado com sucesso");
                }

                return RespostaCustomizada();
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
                if(await _usuarioService.Deletar(id))
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
