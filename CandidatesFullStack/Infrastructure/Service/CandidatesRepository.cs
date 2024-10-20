using AutoMapper;
using BeeEngineering.Data;
using BeeEngineering.Domain.Dto;
using BeeEngineering.Models;
using Microsoft.EntityFrameworkCore;

namespace BeeEngineering.Repository
{
    public class CandidatesRepository : ICandidatesRepository
    {
        private readonly ILogger<CandidatesRepository> _logger;
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public CandidatesRepository(DataContext context, IMapper mapper, ILogger<CandidatesRepository> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<CandidateModel>> GetAll()
        {
            _logger.LogInformation($"Bringing all candidates from database.");
            var candidate = await _context.Candidates.Where(a => a.IsActive).ToListAsync();
            return candidate;
        }

        public async Task<CandidateModel> GetById(int id)
        {
            _logger.LogInformation($"Bringing the candidate by Id {id}");
            var candidate = await _context.Candidates.FirstOrDefaultAsync(x => x.Id == id) 
                ?? throw new ArgumentException("Candidate not found", nameof(id));
            return candidate;
        }

        public async Task<CandidateModel> Create(CandidateDto candidateDto)
        {
            if(candidateDto is null)
                throw new ArgumentException("candidate can't be null here.", nameof(candidateDto));
            _logger.LogInformation("Tring to create the candidate in the database.");                
            try
            {
                var candidate = _mapper.Map<CandidateModel>(candidateDto) 
                    ?? throw new InvalidOperationException("Mapping failed to create a valid CandidateModel.");
                await _context.Candidates.AddAsync(candidate);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Success! candidate created and saved.");
                return candidate;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error to save the candidate in the database: {ex.Message}");
                throw;
            }
        }

        public async Task<CandidateModel> Update(CandidateDto candidateDto)
        {
            if(candidateDto is null)
                throw new ArgumentException("candidate can't be null here.", nameof(candidateDto));
            _logger.LogInformation("Tring to update the candidate in the database.");                
            try
            {
                var candidate = _mapper.Map<CandidateModel>(candidateDto) 
                    ?? throw new InvalidOperationException("Mapping failed to create a valid CandidateModel.");
                _context.Candidates.Update(candidate);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Success! candidate updated and saved.");
                return candidate;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error to update the candidate in the database: {ex.Message}");
                throw;
            }
        }

        public async Task<CandidateModel> Delete(int id)
        {
            if(id <= 0)
                throw new ArgumentException("Id can't be less than 1.", nameof(id));
            _logger.LogInformation("Tring to delete the candidate in the database.");                
            try
            {
                var candidate = await _context.Candidates.FirstOrDefaultAsync(x => x.Id == id) 
                    ?? throw new ArgumentException("Candidate not found", nameof(id));
                candidate.IsActive = false;
                await _context.SaveChangesAsync();
                _logger.LogInformation("Success! candidate deleted and saved.");
                return candidate;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error to delete the candidate in the database: {ex.Message}");
                throw;
            }
        }

    }
}
