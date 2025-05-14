using FluentValidation;
using JobTracker.Entities;
using JobTracker.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JobTracker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JobOfferController : ControllerBase
    {
        private readonly IJobOffersRepository _jobOffersRepository;
        private readonly IValidator<JobOffer> _validator;

        public JobOfferController(IJobOffersRepository jobOffersRepository, IValidator<JobOffer> validator)
        {
            _jobOffersRepository = jobOffersRepository;
            _validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> GetJobOffers()
        {
            return Ok(await _jobOffersRepository.GetJobOffers());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetJobOffer(int id)
        {
            return Ok(await _jobOffersRepository.GetJobOffer(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateJobOffer(JobOffer jobOffer)
        {
            var validationResult = await _validator.ValidateAsync(jobOffer);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.ToDictionary());
            }
            await _jobOffersRepository.CreateJobOffer(jobOffer);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateJobOffer(JobOffer jobOffer)
        {
            var validationResult = await _validator.ValidateAsync(jobOffer);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.ToDictionary());
            }
            return await _jobOffersRepository.UpdateJobOffer(jobOffer) ? Ok() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobOffer(int id)
        {
            await _jobOffersRepository.DeleteJobOffer(id);
            return NoContent();
        }
    }
}
