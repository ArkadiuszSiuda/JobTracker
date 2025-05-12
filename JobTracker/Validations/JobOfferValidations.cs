using FluentValidation;
using JobTracker.Entities;
using System.Runtime.CompilerServices;

namespace JobTracker.Validations;

public class JobOfferValidations : AbstractValidator<JobOffer>
{
    public JobOfferValidations()
    {
        RuleFor(x => x.CompanyName)
             .NotEmpty()
             .WithMessage(JobOfferErrors.CompanyNameRequiredMessage);
        RuleFor(x => x.Position)
             .NotNull()
             .WithMessage(JobOfferErrors.PositionRequiredMessage);
        RuleFor(x => x.SalaryRange)
            .Must(x => SalaryRangeValidatr(x))
            .WithMessage(JobOfferErrors.SalaryRangeErrorMessage);
        RuleFor(x => x.Note)
             .Length(0, 100)
             .WithMessage(JobOfferErrors.NoteLengthErrorMessage);
        RuleFor(x => x.Link)
             .NotEmpty()
             .WithMessage(JobOfferErrors.LinkRequiredMessage)
             .Must(link => Uri.IsWellFormedUriString(link, UriKind.Absolute))
             .WithMessage(JobOfferErrors.LinkInvalidMessage);
        RuleFor(x => x.SubmissionDate)
             .Must(date => date != default)
             .WithMessage(JobOfferErrors.SubmissionDateErrorMessage);
        RuleFor(x => x.Status)
             .NotNull()
             .WithMessage(JobOfferErrors.StatusRequiredMessage);


    }
    
    private static bool SalaryRangeValidatr(SalaryRange salaryRange)
    {
        return salaryRange.Min > 0 && salaryRange.Max > 0 && salaryRange.Min < salaryRange.Max;
    }
}
