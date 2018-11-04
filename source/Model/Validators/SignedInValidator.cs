using FluentValidation;
using Solution.CrossCutting.Utils.Resources;
using Solution.Model.Models;

namespace Solution.Model.Validators
{
    public sealed class SignedInValidator : Validator<SignedInModel>
    {
        public SignedInValidator() : base(Texts.LoginPasswordInvalid)
        {
            RuleFor(x => x).NotNull();
            RuleFor(x => x.UserId).GreaterThan(0);
        }
    }
}
