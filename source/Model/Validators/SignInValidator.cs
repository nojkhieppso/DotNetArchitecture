using FluentValidation;
using Solution.CrossCutting.Utils.Resources;
using Solution.Model.Models;

namespace Solution.Model.Validators
{
    public sealed class SignInValidator : Validator<SignInModel>
    {
        public SignInValidator() : base(Texts.LoginPasswordInvalid)
        {
            RuleFor(x => x).NotNull();
            RuleFor(x => x.Login).NotNull().NotEmpty();
            RuleFor(x => x.Password).NotNull().NotEmpty();
        }
    }
}
