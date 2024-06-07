using DigitasChallenge.DAL.Entities;
using DigitasChallenge.DAL.Repositories.Interfaces;

namespace DigitasChallenge.DAL.Repositories
{
    public class TasksRepository : ITasksRepository
    {
        private readonly IRepository<Tasks> _tasksRepository;
        private readonly DigitasContext _context;

        public TasksRepository(IRepository<Tasks> tasksRepository, DigitasContext context)
        {
            _tasksRepository = tasksRepository;
            _context = context;
        }

        public void Add(Tasks entity)
        {
            _tasksRepository.Add(entity);
        }

        public bool DoesNotHaveTheSameName(int id, string name)
        {
            return _context.Tasks.Any(t => !t.Id.Equals(id) && t.Name.Equals(name));
        }

        public IEnumerable<Tasks> GetAll()
        {
            return _tasksRepository.GetAll();       
        }

        public Tasks GetById(int id)
        {
            return _tasksRepository.GetById(id);
        }

        public void Update(Tasks entity)
        {
            _tasksRepository.Update(entity);
        }

        public void Remove(Tasks entity) 
        {
            _tasksRepository.Remove(entity);
        }
    }
}