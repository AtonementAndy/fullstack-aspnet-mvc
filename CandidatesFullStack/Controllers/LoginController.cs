using BeeEngineering.Domain.Dto;
using BeeEngineering.Domain.Interfaces;
using BeeEngineering.Domain.Models;
using BeeEngineering.Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;

namespace BeeEngineering.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILoginService loginService, ILogger<LoginController> logger)
        {
            _loginService = loginService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] LoginDto loginDto)
        {
            _logger.LogInformation("Checando nulidade antes de criar login.");
            if(string.IsNullOrEmpty(loginDto.Email) || string.IsNullOrEmpty(loginDto.Senha))
                return BadRequest("Email e senha são obrigatórios");
                     
            try
            {
                var login = await _loginService.SalvarLogin(loginDto);
                _logger.LogInformation("Login criado com sucesso.");
                return CreatedAtRoute(nameof(Create), login);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Erro ao salvar login.");
                return Conflict("Login já existe no banco de dados.");
            }
        }
    }
}