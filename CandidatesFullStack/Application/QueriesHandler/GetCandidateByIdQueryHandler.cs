using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BeeEngineering.Application.Queries;
using BeeEngineering.Domain.Dto;
using BeeEngineering.Repository;
using MediatR;

namespace BeeEngineering.Application.QueriesHandler
{
    public class GetCandidateByIdQueryHandler(CandidatesRepository candidateService, ILogger<GetCandidateByIdQueryHandler> logger, IMapper mapper) : IRequestHandler<GetCandidateByIdQuery, CandidateDto>
    {
        private readonly CandidatesRepository _candidateService = candidateService;
        private readonly ILogger<GetCandidateByIdQueryHandler> _logger = logger;
        private readonly IMapper _mapper = mapper;

        public async Task<CandidateDto> Handle(GetCandidateByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Getting candidateBy Id {request.Id} through CQRS.");

            var candidate = await _candidateService.GetById(request.Id);
            return _mapper.Map<CandidateDto>(candidate);
        }
    }
}