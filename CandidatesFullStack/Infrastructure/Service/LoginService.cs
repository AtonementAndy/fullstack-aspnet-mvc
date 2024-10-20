using AutoMapper;
using BeeEngineering.Data;
using BeeEngineering.Domain.Dto;
using BeeEngineering.Domain.Interfaces;
using BeeEngineering.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BeeEngineering.Infrastructure.Service
{
    public class LoginService : ILoginService
    {
        private readonly DataContext _context;
        private readonly ILogger<LoginService> _logger;
        private readonly IMapper _mapper;

        public LoginService(DataContext context, ILogger<LoginService> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<Login> SalvarLogin(LoginDto loginDto)
        {
            _logger.LogInformation("Tentativa de salvar login.");
            if(loginDto == null)
                throw new ArgumentNullException(nameof(loginDto));

            var login = _mapper.Map<Login>(loginDto) 
                ?? throw new InvalidOperationException("Mapping resulted in a null Login object.");

            var loginExistente = await _context.Logins
                .FirstOrDefaultAsync(l => l.Email == loginDto.Email);
            if(loginExistente is not null)
            {
                _logger.LogWarning("Login já existe no banco de dados.");
                throw new InvalidOperationException("Conflict: Login already exists.");
            }
            
            try
            {
                await _context.Logins.AddAsync(login);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Login criado e salvo com sucesso.");
                return login;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Erro inesperado ao criar o login.");
                throw;
            }
        }
    }

}
