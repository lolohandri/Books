using Microsoft.AspNetCore.Razor.Hosting;
using Microsoft.EntityFrameworkCore;
using Books.Data;
using Books.Interfaces;
using Books.Models;

namespace Books.Repository
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly DataContext _context;
        internal DbSet<T> DbSet { get; set; }
        public GenericRepository(DataContext context)
        {
            _context = context;
            this.DbSet = _context.Set<T>();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return this.DbSet.ToList();
        }

        public virtual T Get(long id)
        {
            return this.DbSet.Find(id);
        }

        public virtual void Create(T item)
        {
            this.DbSet.Add(item);
        }

        public virtual bool Update(long id, T item)
        {
            throw new NotImplementedException();
        }

        public virtual bool Delete(long id)
        {
            throw new NotImplementedException();
        }
    }
}
