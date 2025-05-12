namespace JobTracker.Validations;

public class JobOfferErrors
{
    public static string CompanyNameRequiredMessage { get; set; } = "Company name cannot be null or empty.";
    public static string PositionRequiredMessage { get; set; } = "Position cannot be null or empty.";
    public static string SalaryRangeErrorMessage { get; set; } = "Salary maximum value cannot be lower than minimum value";
    public static string NoteLengthErrorMessage { get; set; } = "Note must be less than 100 characters.";
    public static string LinkRequiredMessage { get; set; } = "Link cannot be null or empty.";
    public static string LinkInvalidMessage { get; set; } = "Link must be a valid URL.";
    public static string SubmissionDateErrorMessage { get; set; } = "Submission date cannot be default value.";
    public static string StatusRequiredMessage { get; set; } = "Status cannot be null or empty.";
}
