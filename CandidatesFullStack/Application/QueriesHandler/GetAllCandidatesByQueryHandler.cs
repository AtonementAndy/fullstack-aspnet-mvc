using AutoMapper;
using BeeEngineering.Application.Queries;
using BeeEngineering.Domain.Dto;
using BeeEngineering.Repository;
using MediatR;

namespace BeeEngineering.Application.QueriesHandler
{
    public class GetAllCandidatesQueryHandler(CandidatesRepository candidateService, ILogger<GetAllCandidatesQueryHandler> logger, IMapper mapper) : IRequestHandler<GetAllCandidatesQuery, List<CandidateDto>>
    {
        private readonly CandidatesRepository _candidateService = candidateService;
        private readonly ILogger<GetAllCandidatesQueryHandler> _logger = logger;
        private readonly IMapper _mapper = mapper;

        public async Task<List<CandidateDto>> Handle(GetAllCandidatesQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Getting a candidates through CQRS.");

            var candidates = await _candidateService.GetAll();
            return _mapper.Map<List<CandidateDto>>(candidates);
        }
    }
}