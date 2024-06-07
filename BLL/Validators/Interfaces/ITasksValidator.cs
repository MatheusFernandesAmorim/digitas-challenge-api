using DigitasChallenge.BLL.Models;

namespace DigitasChallenge.BLL.Validators.Interfaces
{
    public interface ITasksValidator
    {
        void ValidateTask(SimpleTasksModel model, bool checkByName);
    }
}