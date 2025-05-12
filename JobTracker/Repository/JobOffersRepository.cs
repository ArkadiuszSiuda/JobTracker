using JobTracker.Db;
using JobTracker.Entities;
using JobTracker.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JobTracker.Repository;

public class JobOffersRepository : IJobOffersRepository
{
    private readonly JobTrackerContext _context;

    public JobOffersRepository(JobTrackerContext context)
    {
        _context = context;
    }

    public async Task<IList<JobOffer>> GetJobOffers()
    {
        var dbJobOffers = await _context.JobOffers.ToListAsync();

        return dbJobOffers;
    }

    public async Task<JobOffer> GetJobOffer(int id)
    {
        var dbJobOffer = await _context.JobOffers.FirstOrDefaultAsync(i => i.Id == id);

        return dbJobOffer;
    }

    public async Task CreateJobOffer(JobOffer jobOffer)
    {
        await _context.AddAsync(jobOffer);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateJobOffer(JobOffer jobOffer)
    {
        var dbJobOffer = await _context.JobOffers.FirstOrDefaultAsync(i => i.Id == jobOffer.Id);
        if (dbJobOffer == null)
        {
            throw new Exception($"Job offer with id {jobOffer.Id} does not exist");
        }
        dbJobOffer.CompanyName = jobOffer.CompanyName;
        dbJobOffer.Position = jobOffer.Position;
        dbJobOffer.SalaryRange = jobOffer.SalaryRange;
        dbJobOffer.Note = jobOffer.Note;
        dbJobOffer.Link = jobOffer.Link;
        dbJobOffer.SubmissionDate = jobOffer.SubmissionDate;
        dbJobOffer.Status = jobOffer.Status;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteJobOffer(int id)
    {
        var jobOffer = await _context.JobOffers.FirstOrDefaultAsync(i => i.Id == id);
        _context.Remove(jobOffer);
        await _context.SaveChangesAsync();
    }
}
