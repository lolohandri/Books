using Books.Data;
using Books.Interfaces;
using Books.Models;

namespace Books.Repository
{
    public class MotorcycleRepository : GenericRepository<Motorcycle>
    {
        public MotorcycleRepository(DataContext context) : base(context) { }

        public override IEnumerable<Motorcycle> GetAll()
        {
            return base.GetAll();
        }
        public override Motorcycle Get(long id)
        {
            return base.Get(id);
        }
        public override void Create(Motorcycle item)
        {
            base.Create(item);
        }
        public override bool Delete(long id)
        {
            try
            {
                var item = this.DbSet.FirstOrDefault(x => x.Id == id);
                if(item != null)
                {
                    this.DbSet.Remove(item);
                    return true;
                }
                else { return false; }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public override bool Update(long id, Motorcycle item)
        {
            try
            {
                var value = this.DbSet.FirstOrDefault(x => x.Id == id);
                if(value!= null)
                {
                    value.Name = item.Name;
                    value.Description = item.Description;
                    value.Image = item.Image;
                    value.Price = item.Price;
                    return true;
                }
                else { return false; }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
