using AutoMapper;
using BeeEngineering.Domain.Dto;
using BeeEngineering.Domain.Models;
using BeeEngineering.Models;

namespace BeeEngineering.Domain.Mapping
{
    public class CandidatesProfile : Profile
    {
        public CandidatesProfile()
        {
            CreateMap<CandidateModel, CandidateDto>();
            CreateMap<CandidateDto, CandidateModel>()
                .ForMember(dest => dest.IsActive, opt => opt.Ignore());
        }
    }
}