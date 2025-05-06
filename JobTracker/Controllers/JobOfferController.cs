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

        public JobOfferController(IJobOffersRepository jobOffersRepository)
        {
            _jobOffersRepository = jobOffersRepository;
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
            await _jobOffersRepository.CreateJobOffer(jobOffer);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateJobOffer(JobOffer jobOffer)
        {
            await _jobOffersRepository.UpdateJobOffer(jobOffer);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobOffer(int id)
        {
            await _jobOffersRepository.DeleteJobOffer(id);
            return NoContent();
        }
    }
}
