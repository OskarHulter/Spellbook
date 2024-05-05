using ArcaneLibrary.Domain;

namespace ArcaneLibrary.Validators;

public class SectionValidator : AbstractValidator<SpellType>
{
    public SectionValidator()
    {
        RuleFor(p => p.Name).NotEmpty();
    }
}