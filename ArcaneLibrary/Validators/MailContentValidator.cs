using ArcaneLibrary.Domain;

namespace ArcaneLibrary.Validators;

//.CascadeMode(CascadeMode.StopOnFirstFailure)
// Localized Messages!
public class MailContentValidator : AbstractValidator<MailContentType>
{
    public MailContentValidator()
    {
        RuleFor(p => p.Title)
            .NotEmpty().WithMessage("{PropertyName} is Empty")
            .Length(2, 50).WithMessage("Length {TotalLength} of {PropertyName} is Invalid")
            .Must(BeAValidName).WithMessage("{PropertyName} Contains Invalid Characters");
        RuleFor(p => p.CompanyName)
            .NotEmpty().WithMessage("{PropertyName} is Empty")
            .Length(2, 50).WithMessage("Length {TotalLength} of {PropertyName} is Invalid")
            .Must(BeAValidName).WithMessage("{PropertyName} Contains Invalid Characters");
        RuleFor(p => p.Location)
            .NotEmpty().WithMessage("{PropertyName} is Empty")
            .Length(2, 50).WithMessage("Length {TotalLength} of {PropertyName} is Invalid")
            .Must(BeAValidName).WithMessage("{PropertyName} Contains Invalid Characters");
        RuleFor(p => p.UnsubscribeLink).NotEmpty();
        RuleFor(p => p.WebsiteLink).NotEmpty();
    }

    protected bool BeAValidName(string name)
    {
        name = name.Replace(" ", "");
        name = name.Replace("-", "");
        return name.All(char.IsLetter);
    }
}