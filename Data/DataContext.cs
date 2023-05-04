using Microsoft.EntityFrameworkCore;
using Books.Models;
using Books.Interfaces;
using Books.Repository;

namespace Books.Data
{
	public class DataContext : DbContext
	{
		public DbSet<Motorcycle> Motorcycles {  get; set; }

		public DataContext() { }
		public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    }
}
