using DigitasChallenge.DAL.Entities;

namespace DigitasChallenge.DAL.Repositories.Interfaces
{
    public interface ITasksRepository
    {
        public IEnumerable<Tasks> GetAll();
        public bool DoesNotHaveTheSameName(int id, string name);
        public Tasks GetById(int id);
        public void Add(Tasks entity);
        public void Update(Tasks entity);
        public void Remove(Tasks entity);
    }
}