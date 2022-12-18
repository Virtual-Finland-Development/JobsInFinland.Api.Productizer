using FluentValidation;
using JobsInFinland.Api.Productizer.Models.Testbed;

namespace JobsInFinland.Api.Productizer.Services.Validation;

public class JobPostingRequestValidator : AbstractValidator<JobsPostingRequest>
{
    public JobPostingRequestValidator()
    {
        RuleFor(x => x.Query).MaximumLength(2048);
        RuleForEach(x => x.Location.Countries).MaximumLength(2);

        // TODO: This regex works on regex website but not in code :(
        /*
        const string occupationUriPattern = "http[s]?:////data.europa.eu//esco//((isco)|(occupation))//((C[0-9]*)|([0-9A-Fa-f]{8}-([0-9A-Fa-f]{4}-){3}[0-9A-Fa-f]{12}))";
        RuleForEach(x => x.Requirements.Occupations).Matches(occupationUriPattern);
        */

        RuleForEach(x => x.Location.Municipalities).Length(3);
        RuleForEach(x => x.Location.Countries).Length(2);
    }
}
