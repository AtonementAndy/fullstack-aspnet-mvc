using BeeEngineering.Domain.Dto;
using BeeEngineering.Models;

namespace BeeEngineering.Repository
{
    public interface ICandidatesRepository
    {
        Task<IEnumerable<CandidateModel>> GetAll();
        Task<CandidateModel> GetById(int id);
        Task<CandidateModel> Create(CandidateDto candidateDto);
        Task<CandidateModel> Update(CandidateDto candidateDto);
        Task<CandidateModel> Delete(int id);

    }
}
