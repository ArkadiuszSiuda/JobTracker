using JobTracker.Entities;

namespace JobTracker.Interfaces;

public interface IJobOffersRepository
{
    Task<IList<JobOffer>> GetJobOffers();
    Task<JobOffer> GetJobOffer(int id);
    Task CreateJobOffer(JobOffer jobOffer);
    Task<bool> UpdateJobOffer(JobOffer jobOffer);
    Task DeleteJobOffer(int id);
}
