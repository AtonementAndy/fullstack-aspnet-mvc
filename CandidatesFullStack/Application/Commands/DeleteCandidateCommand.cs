using BeeEngineering.Domain.Dto;
using MediatR;

namespace BeeEngineering.Application.Commands
{
    public class DeleteCandidateCommand(int id) : IRequest<CandidateDto>
    {
        public int Id { get; set; } = id;
    }
}