using DigitasChallenge.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DigitasChallenge.DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbSet<T> _dbSet;
        private readonly DigitasContext _context;

        public Repository(DigitasContext context)
        {
            _dbSet = context.Set<T>();
            _context = context;
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Add(T entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }

        public void Remove(T entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }       
    }
}
