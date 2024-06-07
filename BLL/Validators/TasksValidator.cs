using DigitasChallenge.BLL.Models;
using DigitasChallenge.BLL.Validators.Interfaces;
using FluentValidation;

namespace DigitasChallenge.BLL.Validators
{
    public class TasksValidator : Validator<SimpleTasksModel>, ITasksValidator
    {
        public void ValidateTask(SimpleTasksModel model, bool checkByName)
        {
            RuleFor(t => t.Name).NotEmpty()
                .WithMessage("The name cannot be empty or null.");

            RuleFor(t => t.Name).Must(t => !checkByName)
                .WithMessage("The informed name is already being used in a previous record.");

            RuleFor(t => t.Description).NotEmpty()
               .WithMessage("The description cannot be empty or null.");

            RuleFor(t => t.Starts).NotEmpty()
                .WithMessage("The starting date cannot be empty or null.");

            RuleFor(t => t.Starts).LessThanOrEqualTo(t => t.Ends)
                .WithMessage("The starting date cannot be greater than ending date.");

            RuleFor(t => t.Ends).NotEmpty()
                .WithMessage("The ending date cannot be empty or null.");

            ValidateObject(model);
        }
    }
}
