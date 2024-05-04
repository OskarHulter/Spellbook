using ArcaneLibrary.Domain;

namespace ArcaneLibrary.Validators;

public class SpellValidator : AbstractValidator<SpellType>
{
    public SpellValidator()
    {
        RuleFor(p => p.Name).NotEmpty();
    }
}