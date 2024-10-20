using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeeEngineering.Domain.Dto;
using MediatR;

namespace BeeEngineering.Application.Queries
{
    public class GetAllCandidatesQuery : IRequest<List<CandidateDto>>
    {
        
    }
}