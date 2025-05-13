using FluentValidation;
using JobTracker.Entities;

namespace JobTracker.Validations;

public class JobOfferValidations : AbstractValidator<JobOffer>
{
    public JobOfferValidations()
    {
        RuleFor(x => x.SalaryRange)
            .Must(x => SalaryRangeValidatr(x))
            .WithMessage("Salary maximum value cannot be lower than minimum value");
        RuleFor(x => x.Note)
             .Length(0, 100)
             .WithMessage("Note must be less than 100 characters.");
        RuleFor(x => x.Link)
             .Must(link => Uri.IsWellFormedUriString(link, UriKind.Absolute))
             .WithMessage("Link must be a valid URL.");
        RuleFor(x => x.SubmissionDate)
             .Must(date => date != default)
             .WithMessage("Submission date cannot be default value.");


    }
    
    private static bool SalaryRangeValidatr(SalaryRange salaryRange)
    {
        return salaryRange.Min > 0 && salaryRange.Max > 0 && salaryRange.Min < salaryRange.Max;
    }
}
