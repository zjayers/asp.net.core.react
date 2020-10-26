using FluentValidation;

namespace Core.Validators
{
    public static class ValidatorExtensions
    {
        public static IRuleBuilder<T, string> AppPassword<T>(this IRuleBuilder<T, string> builder)
        {
            return builder
                .MinimumLength(6)
                .WithMessage("Password must be at least 6 characters long")
                .Matches("[A-Z]")
                .WithMessage("Password must contain at least 1 uppercase character")
                .Matches("[a-z]")
                .WithMessage("Password must contain at least 1 lowercase character")
                .Matches("[0-9]")
                .WithMessage("Password must contain at least 1 number")
                .Matches("[^a-zA-z0-9]")
                .WithMessage("Password must contain at least 1 non alpha-numeric character");
        }
    }
}