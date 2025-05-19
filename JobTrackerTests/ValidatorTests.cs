using FluentValidation;
using JobTracker.Controllers;
using JobTracker.Entities;
using JobTracker.Interfaces;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace JobTrackerTests;
public class ValidatorTests
{
    private IJobOffersRepository _jobsOfferRepository;
    private IValidator<JobOffer> _validator;
    private JobOfferController _controller;

    public ValidatorTests()
    {
        _jobsOfferRepository = Substitute.For<IJobOffersRepository>();
        _validator = new InlineValidator<JobOffer>();
        _controller = new JobOfferController(_jobsOfferRepository, _validator);
    }

    [Fact]
    public async void UpdateJobOfferReturnsUpdatedJobOffer()
    {
        var jobOffer = new DataGenerator().GenerateJobOffers(2);

        _jobsOfferRepository.GetJobOffer(jobOffer[0].Id).Returns(jobOffer[0]);

        var actionResult = await _controller.GetJobOffer(jobOffer[0].Id);

        var result = actionResult as OkObjectResult;

        var jobOfferToUpdate = result.Value as JobOffer;
        jobOfferToUpdate.CompanyName = "Updated Company Name";

        await _controller.UpdateJobOffer(jobOfferToUpdate);

        await _jobsOfferRepository.Received(1).UpdateJobOffer(Arg.Is<JobOffer>(c => c.CompanyName == jobOfferToUpdate.CompanyName));

        Assert.Equal(200, result!.StatusCode);
    }
}
