using Books.Models;
using Microsoft.EntityFrameworkCore;

namespace Books.Data
{
    public class BooksContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
    }
}
