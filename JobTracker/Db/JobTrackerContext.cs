using JobTracker.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Text.Json;

namespace JobTracker.Db;

public class JobTrackerContext : DbContext
{
    public JobTrackerContext(DbContextOptions<JobTrackerContext> options) : base(options)
    {

    }

    public DbSet<JobOffer> JobOffers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var options = new JsonSerializerOptions();
        var converter = new ValueConverter<SalaryRange, string>(
            v => JsonSerializer.Serialize(v, options),
            v => JsonSerializer.Deserialize<SalaryRange>(v, options));

        modelBuilder.Entity<JobOffer>()
            .Property(e => e.SalaryRange)
            .HasConversion(converter)
            .HasColumnType("TEXT");

        base.OnModelCreating(modelBuilder);
    }
    ss
}
