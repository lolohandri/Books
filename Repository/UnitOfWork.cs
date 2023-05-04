using Microsoft.EntityFrameworkCore;
using Books.Data;
using Books.Interfaces;
using Books.Models;

namespace Books.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public MotorcycleRepository MotorcycleRepository { get; set; }
        private readonly DataContext _context;

        public UnitOfWork(DataContext context)
        {
            _context = context;
            MotorcycleRepository = new MotorcycleRepository(context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
