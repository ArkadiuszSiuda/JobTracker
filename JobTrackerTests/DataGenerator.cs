using Bogus;
using JobTracker.Entities;

namespace JobTrackerTests;
public class DataGenerator
{
    Faker<JobOffer> _jobOfferFaker;
    public DataGenerator()
    {
        _jobOfferFaker = new Faker<JobOffer>()
            .CustomInstantiator(f => new JobOffer
            {
                Id = f.IndexFaker,
                CompanyName = f.Company.CompanyName(),
                Position = f.Name.JobTitle(),
                SalaryRange = new SalaryRange
                {
                    Min = f.Random.Int(30000, 60000),
                    Max = f.Random.Int(60001, 100000)
                },
                Note = f.Lorem.Sentence(),
                Link = f.Internet.Url(),
                SubmissionDate = f.Date.Past(1),
                Status = (Statuses)f.Random.Int(0, 3)
            });
    }

    public List<JobOffer> GenerateJobOffers(int count)
    {
        return _jobOfferFaker.Generate(count);
    }
}
