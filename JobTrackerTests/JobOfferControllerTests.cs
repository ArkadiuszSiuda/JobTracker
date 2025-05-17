using Bogus;
using FluentValidation;
using JobTracker.Controllers;
using JobTracker.Entities;
using JobTracker.Interfaces;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NSubstitute.ReceivedExtensions;

namespace JobTrackerTests;

public class JobOfferControllerTests
{
    private IJobOffersRepository _jobsOfferRepository;
    private IValidator<JobOffer> _validator;
    private JobOfferController _controller;

    public JobOfferControllerTests()
    {
        _jobsOfferRepository = Substitute.For<IJobOffersRepository>();
        _validator = new InlineValidator<JobOffer>();
        _controller = new JobOfferController(_jobsOfferRepository, _validator);
    }

    [Fact]
    public async void GetJobOffersReturnsCorrectNumberOfOffers()
    {
        var jobOffers = new DataGenerator().GenerateJobOffer(5);

        _jobsOfferRepository.GetJobOffers().Returns(jobOffers);

        var actionResult = await _controller.GetJobOffers();

        var result = actionResult as OkObjectResult;

        Assert.Equivalent(jobOffers, (List<JobOffer>)result!.Value!);
    }

    [Fact]
    public async void GetJobOfferReturnsCorrectJobOffer()
    {
        var jobOffer = new DataGenerator().GenerateJobOffer(1);

        _jobsOfferRepository.GetJobOffer(jobOffer[0].Id).Returns(jobOffer[0]);

        var actionResult = await _controller.GetJobOffer(jobOffer[0].Id);

        var result = actionResult as OkObjectResult;

        Assert.Equivalent(jobOffer[0], result!.Value!);
    }

    [Fact]
    public async void PostJobOffersReturnsCorrectNumberOfOffers()
    {

        var jobOffer = new DataGenerator().GenerateJobOffer(1);

        var actionResult = await _controller.CreateJobOffer(jobOffer[0]);

        var result = actionResult as OkResult;

        await _jobsOfferRepository.Received(1).CreateJobOffer(Arg.Is<JobOffer>(i => i.Id == jobOffer[0].Id));

        Assert.Equal(200, result!.StatusCode);
    }

    [Fact]
    public async void DeleteJobOfferReturnsNoContent()
    {

        var jobOffer = new DataGenerator().GenerateJobOffer(1);

        var actionResult = await _controller.DeleteJobOffer(jobOffer[0].Id);

        var result = actionResult as NoContentResult;

        _jobsOfferRepository.Received(0);

        Assert.Equal(204, result!.StatusCode);
    }

    //delete, update, post validacja, update validancja
}