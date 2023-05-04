using Books.Repository;

namespace Books.Interfaces
{
    public interface IUnitOfWork
    {
        MotorcycleRepository MotorcycleRepository { get; set; }
        void Save();
    }
}
