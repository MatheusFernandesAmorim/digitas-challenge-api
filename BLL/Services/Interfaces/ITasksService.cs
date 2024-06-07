using DigitasChallenge.BLL.Models;

namespace DigitasChallenge.BLL.Services.Interfaces
{
    public interface ITasksService
    {
        public IEnumerable<CompleteTasksModel> GetAll();
        public CompleteTasksModel GetById(int id);        
        public void Add(SimpleTasksModel model);
        public void Update(CompleteTasksModel model);
        public void Remove(int id);
        public void AddAll();
        public void RemoveAll();
    }
}