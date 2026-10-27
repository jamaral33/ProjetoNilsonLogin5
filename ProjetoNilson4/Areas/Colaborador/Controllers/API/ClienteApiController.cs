using Microsoft.AspNetCore.Mvc;
using ProjetoNilson4.Models;
using ProjetoNilson4.Repository.Contract;

namespace ProjetoNilson4.Areas.Colaborador.Controllers.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteApiController : Controller
    {
        private IClienteRepository _clienteRepository;
        public ClienteApiController(IClienteRepository clienteRepository){
            _clienteRepository = clienteRepository;
        }

        [HttpGet]
        public IActionResult ListarClientes()
        {
            var clientes = _clienteRepository.ObterTodosClientes();

            return Ok(clientes);
        }

        [HttpPost]
        public IActionResult Cadastrar([FromBody] Cliente cliente)
        {
            if(cliente is null)
            {
                return BadRequest(new
                {
                    mensagem = "Os dados de cliente são obrigatórios."
                });
            }
            _clienteRepository.Cadastrar(cliente);

            return Ok(new
            {
                mensagem = "Cadastro realizado com sucesso.",
                cliente
            });
        }
    }
}