using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeeEngineering.Domain.Dto;
using BeeEngineering.Domain.Models;

namespace BeeEngineering.Domain.Interfaces
{
    public interface ILoginService
    {
        Task<Login> SalvarLogin(LoginDto loginDto);
    }
}