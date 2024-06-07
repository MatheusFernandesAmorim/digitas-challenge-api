using FluentValidation;
using FluentValidation.Results;

namespace DigitasChallenge.BLL.Validators
{
    public abstract class Validator<T> : AbstractValidator<T>, IValidator<T>
    {
        private void ValidateMessage(ValidationResult result)
        {
            if (!result.IsValid)
            {
                string errorMessage = string.Empty;

                result.Errors = result.Errors.DistinctBy(e => e.ErrorMessage).ToList();

                foreach (var error in result.Errors)
                {
                    errorMessage += $"{error.ErrorMessage}{Environment.NewLine}";
                }

                throw new Exception(errorMessage);
            }
        }

        public void ValidateObject(T validant)
        {
            ValidationResult result = Validate(validant);

            ValidateMessage(result);
        }
    }
}