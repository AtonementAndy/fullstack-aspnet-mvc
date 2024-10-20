using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BeeEngineering.Application.Commands;
using BeeEngineering.Domain.Dto;
using BeeEngineering.Repository;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BeeEngineering.Application.CommandHandler
{
    public class CreateCandidateCommandHandler(CandidatesRepository candidateService, ILogger<CreateCandidateCommandHandler> logger, IMapper mapper) : IRequestHandler<CreateCandidateCommand, CandidateDto>
    {
        private readonly CandidatesRepository _candidateService = candidateService;
        private readonly ILogger<CreateCandidateCommandHandler> _logger = logger;
        private readonly IMapper _mapper = mapper;

        public async Task<CandidateDto> Handle(CreateCandidateCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Creating a candidate through CQRS.");

            var candidate = await _candidateService.Create(request.CandidateDto);
            var candidateMapped = _mapper.Map<CandidateDto>(candidate);
            return candidateMapped;
        }
    }
}