namespace Books.Data
{
    public class UnitOfWork : IDisposable
    {
        private BooksContext context = new BooksContext();
        private BookRepository bookRepository;

        public BookRepository Books
        {
            get
            {
                if(bookRepository is null)
                {
                    bookRepository = new BookRepository(context);
                }
                return bookRepository;
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
        }
    }
}
