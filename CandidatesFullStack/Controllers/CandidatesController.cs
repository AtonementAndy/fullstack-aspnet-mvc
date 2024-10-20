using AutoMapper;
using BeeEngineering.Application.Commands;
using BeeEngineering.Application.Queries;
using BeeEngineering.Domain.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BeeEngineering.Controllers
{
    public class CandidatesController(IMediator mediator, ILogger<CandidatesController> logger, IMapper mapper) : Controller
    {
        private readonly ILogger<CandidatesController> _logger = logger;

        private readonly IMapper _mapper = mapper;

        private readonly IMediator _mediator = mediator;


        // GETALL
        public async Task<IActionResult> Index()
        {
            var candidate = await _mediator.Send(new GetAllCandidatesQuery());
            return View(candidate);
        }

        // CREATE
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CandidateDto candidateDto)
        {
            _logger.LogInformation($"Trying to creating a new candidate {candidateDto.Name}");
            try
            {
                if (ModelState.IsValid)
                {
                    _logger.LogInformation($"Tentando criar um novo contato {candidateDto.Name}");
                    var contato = await _mediator.Send(new CreateCandidateCommand { CandidateDto = candidateDto });
                    return RedirectToAction("Index");
                }

                _logger.LogInformation($"Contato {candidateDto.Name} Id: {candidateDto.Id} foi criado.");
                return View(candidateDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected erro while creating the candidate.");
                return RedirectToAction("Index");
            }
        }

        // UPDATE
        public async Task<IActionResult> Update(int id)
        {
            var candidate = await _mediator.Send(new GetCandidateByIdQuery(id));
            var candidateMapped = _mapper.Map<CandidateDto>(candidate);
            return View(candidateMapped);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CandidateDto candidateDto)
        {
            _logger.LogInformation($"Trying to update a candidate {candidateDto.Name}");
            try
            {
                if (ModelState.IsValid)
                {
                    _logger.LogInformation($"Tentando criar um novo atualizar {candidateDto.Name}");
                    await _mediator.Send(new UpdateCandidateCommand { CandidateDto = candidateDto });
                    return RedirectToAction("Index");
                }
                _logger.LogInformation($"Candidate {candidateDto.Name} Id: {candidateDto.Id} has been updated");
                return View(candidateDto);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Unexpected error updating the candidate.");
                return RedirectToAction("Index");
            }
        }

        // DELETE
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var query = new DeleteCandidateCommand(id);
            var candidate = await _mediator.Send(query);
            _logger.LogInformation($"Candidate {candidate.Name} Id: {candidate.Id} has been deleted");
            return View(candidate);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                _logger.LogInformation($"Trying to desativar a new candidate {id}");
                var command = new DeleteCandidateCommand(id);
                await _mediator.Send(command);
                _logger.LogInformation($"Candidate has been deleted");
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Unexpected error deleting a candidate.");
                return RedirectToAction("Index");
            }
        }
    }
}
