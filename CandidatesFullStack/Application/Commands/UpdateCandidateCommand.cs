using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeeEngineering.Domain.Dto;
using MediatR;

namespace BeeEngineering.Application.Commands
{
    public class UpdateCandidateCommand : IRequest<CandidateDto>
    {
        public CandidateDto CandidateDto { get; set; } = default!;
    }
}