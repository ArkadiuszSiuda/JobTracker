using FluentValidation;
using JobTracker.Entities;

namespace JobTracker.Validations;

public class JobOfferValidations : AbstractValidator<JobOffer>
{
    public JobOfferValidations()
    {
        RuleFor(x => x.CompanyName)
             .NotEmpty()
             .WithMessage("Company name is required.");
        RuleFor(x => x.Position)
             .NotEmpty()
             .WithMessage("Position is required.");
        RuleFor(x => x.SalaryRange)
             .Null()
             .WithMessage("Salary range is not supported yet.");
        RuleFor(x => x.Note)
             .Length(0, 100)
             .WithMessage("Note must be less than 500 characters.");
        RuleFor(x => x.Link)
             .NotEmpty()
             .WithMessage("Link is required.")
             .Must(link => Uri.IsWellFormedUriString(link, UriKind.Absolute))
             .WithMessage("Link must be a valid URL.");
        RuleFor(x => x.SubmissionDate)
             .Must(date => date != default(DateTime));
        RuleFor(x => x.Status)
             .Null()
             .WithMessage("Status is not supported yet.");

    }
}
