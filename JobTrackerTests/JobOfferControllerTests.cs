using Bogus;
using FluentValidation;
using JobTracker.Controllers;
using JobTracker.Entities;
using JobTracker.Interfaces;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace JobTrackerTests;

public class JobOfferControllerTests
{
    private IJobOffersRepository _jobsOfferRepository;
    private IValidator<JobOffer> _validator;

    public JobOfferControllerTests()
    {
        _jobsOfferRepository = Substitute.For<IJobOffersRepository>();
        _validator = new InlineValidator<JobOffer>();
    }

    [Fact]
    public async void GetJobOffersReturnsCorrectNumberOfOffers()
    {
        var controller = new JobOfferController(_jobsOfferRepository, _validator);

        var jobOffers = new DataGenerator().GenerateJobOffer(5);

        _jobsOfferRepository.GetJobOffers().Returns(jobOffers);

        var actionResult = await controller.GetJobOffers();

        var result = actionResult as OkObjectResult;

        Assert.Equivalent(jobOffers, (List<JobOffer>)result!.Value!);
    }
}