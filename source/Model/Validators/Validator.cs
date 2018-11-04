using FluentValidation;
using Solution.CrossCutting.Utils;
using System.Linq;

namespace Solution.Model.Validators
{
    public abstract class Validator<T> : AbstractValidator<T>
    {
        protected Validator()
        {
        }

        protected Validator(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        private string ErrorMessage { get; }

        public void ValidateThrow(T instance)
        {
            if (Equals(instance, default(T)))
            {
                throw new DomainException(ErrorMessage);
            }

            var result = Validate(instance);

            if (result.IsValid)
            {
                return;
            }

            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                throw new DomainException(ErrorMessage);
            }

            throw new DomainException(string.Join(" ", result.Errors.Select(x => x.ErrorMessage)));
        }
    }
}
