using FluentValidation;
using JobTracker.Controllers;
using JobTracker.Entities;
using JobTracker.Repository;
using NSubstitute;

namespace JobTrackerTests;

public class JobOfferControllerTests
{
    private JobOffersRepository _jobsOfferRepository;
    private readonly IValidator<JobOffer> _validator;

    public JobOfferControllerTests()
    {
        _jobsOfferRepository = Substitute.For<JobOffersRepository>();
        _validator = new InlineValidator<JobOffer>();
    }

    [Fact]
    public void GetJobOffersReturnsCorrectNumberOfOffers()
    {
        var fakeJobOffers = new DataGenerator().GenerateJobOffer(5);

        var controller = new JobOfferController(_jobsOfferRepository, _validator);
    }
}