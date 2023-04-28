using Books.Models;

namespace Books.Data
{
    public class BookRepository: IRepository<Book>
    {
        private BooksContext _context;
        public BookRepository(BooksContext context)
        {
            _context = context;
        }

        public void Create(Book item)
        {
            _context.Books.Add(item);
        }

        public void Delete(Guid id)
        {
            var book = _context.Books.FirstOrDefault(x => x.Id == id);
            if (book != null)
            {
                _context.Books.Remove(book);
            }
        }

        public Book Get(Guid id)
        {
            return _context.Books.Find(id);
        }

        public IEnumerable<Book> GetAll()
        {
            return _context.Books;
        }

        public void Update(Book item)
        {
            throw new NotImplementedException();
        }
    }
}
