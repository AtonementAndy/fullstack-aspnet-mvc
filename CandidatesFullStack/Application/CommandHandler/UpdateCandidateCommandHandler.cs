using AutoMapper;
using BeeEngineering.Application.Commands;
using BeeEngineering.Domain.Dto;
using BeeEngineering.Repository;
using MediatR;

namespace BeeEngineering.Application.CommandHandler
{
    public class UpdateCandidateCommandHandler(CandidatesRepository candidateService, ILogger<UpdateCandidateCommandHandler> logger, IMapper mapper) : IRequestHandler<UpdateCandidateCommand, CandidateDto>
    {
        private readonly CandidatesRepository _candidateService = candidateService;
        private readonly ILogger<UpdateCandidateCommandHandler> _logger = logger;
        private readonly IMapper _mapper = mapper;

        public async Task<CandidateDto> Handle(UpdateCandidateCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Updating a candidate through CQRS.");

            var candidate = await _candidateService.Update(request.CandidateDto);
            return _mapper.Map<CandidateDto>(candidate);
        }
    }
}