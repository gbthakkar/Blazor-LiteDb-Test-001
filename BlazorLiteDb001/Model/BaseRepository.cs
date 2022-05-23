using LiteDB;

namespace BlazorLiteDb001.Model
{
    public interface IBaseRepository<T>
    {
        T Insert(T data);
        IEnumerable<T> All();
        T FindById(int id);
        void Update(T entity);
        bool Delete(int id);
    }

    public abstract class BaseRepository<T> : IBaseRepository<T>
    {
        public ILiteDbContext DB { get; }
        public ILiteCollection<T> Collection { get; }
        protected BaseRepository(ILiteDbContext db)
        {
            DB = db;
            Collection = db.Database.GetCollection<T>();
        }
        public virtual T Insert(T entity)
        {
            var newId = Collection.Insert(entity);
            return Collection.FindById(newId.AsInt32);
        }
        public virtual IEnumerable<T> All()
        {
            return Collection.FindAll();
        }
        public virtual T FindById(int id)
        {
            return Collection.FindById(id);
        }

        public virtual void Update(T entity)
        {
            Collection.Upsert(entity);
        }

        public virtual bool Delete(int id)
        {
            return Collection.Delete(id);
        }
    }
}
