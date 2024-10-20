using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BeeEngineering.Application.Commands;
using BeeEngineering.Domain.Dto;
using BeeEngineering.Repository;
using MediatR;

namespace BeeEngineering.Application.CommandHandler
{
    public class DeleteCandidateCommandHandler(CandidatesRepository candidateService, ILogger<DeleteCandidateCommandHandler> logger, IMapper mapper) : IRequestHandler<DeleteCandidateCommand, CandidateDto>
    {
        private readonly CandidatesRepository _candidateService = candidateService;
        private readonly ILogger<DeleteCandidateCommandHandler> _logger = logger;
        private readonly IMapper _mapper = mapper;

        public async Task<CandidateDto> Handle(DeleteCandidateCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Removing a candidate through CQRS.");

            var candidate = await _candidateService.Delete(request.Id);
            return _mapper.Map<CandidateDto>(candidate);
        }
    }
}