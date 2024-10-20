using BeeEngineering.Domain.Dto;
using MediatR;

namespace BeeEngineering.Application.Commands
{
    public class CreateCandidateCommand : IRequest<CandidateDto>
    {
        public CandidateDto CandidateDto { get; set; } = default!;
    }
}