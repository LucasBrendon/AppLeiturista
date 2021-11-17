using Business.Interfaces.Notification;
using Business.Interfaces.Services;
using Business.ViewModels.Leitura;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize]
    public class LeituraController : NotificadorController
    {
        private readonly ILeituraService _leituraService;
        private readonly INotificador _notificador;

        public LeituraController(ILeituraService leituraService, INotificador notificador) : base(notificador)
        {
            _leituraService = leituraService;
            _notificador = notificador;
        }

        [HttpGet]
        [Route("buscar-todos")]
        public async Task<IActionResult> BuscarTodos()
        {
            try
            {
                return Ok(await _leituraService.BuscarTodos());
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
                return RespostaCustomizada(await _leituraService.BuscarPorId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("buscar-por-codigo-cliente/{codigo:long}")]
        public async Task<IActionResult> BuscarPorMatricula(long codigo)
        {
            try
            {
                return RespostaCustomizada(await _leituraService.BuscarPorCodigoCliente(codigo));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("buscar-por-data/{mes:int}")]
        public async Task<IActionResult> BuscarPorData(int mes)
        {
            try
            {
                return RespostaCustomizada(await _leituraService.BuscarPorData(mes));
            }
            catch (Exception ex)
            {
                return BadRequest (ex.Message);
            }
        }

        [HttpPost]
        [Route("cadastrar")]
        [Authorize(Roles = "Gerente, Funcionario")]
        public async Task<IActionResult> Cadastrar(CriarLeituraViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return RespostaCustomizada();
                }
                if(await _leituraService.Cadastrar(model))
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
        [Authorize(Roles = "Gerente, Funcionario")]
        public async Task<IActionResult> Atualizar(EditarLeituraViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return RespostaCustomizada();
                }

                if(await _leituraService.Atualizar(model))
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
                if(await _leituraService.Deletar(id))
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
