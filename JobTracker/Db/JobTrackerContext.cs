using JobTracker.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobTracker.Db;

public class JobTrackerContext : DbContext
{
    public JobTrackerContext(DbContextOptions<JobTrackerContext> options) : base(options)
    {

    }

    public DbSet<JobOffer> JobOffers { get; set; }
    public DbSet<SalaryRange> SalaryRanges { get; set; }    
}
