using FluentValidation.Results;

namespace DigitasChallenge.BLL.Validators.Interfaces
{
    public interface IValidator<T>
    {
        void ValidateMessage(ValidationResult result);
        void ValidateObject(T validant);
    }
}