using InspectionAPI.Data.Entities;

namespace InspectionAPI.Core.Interfaces.Data
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        public Task<T> GetById(int id);
        public IQueryable<T> GetAll();
        public Task Add(T obj);
        public Task Update(T obj);
        public Task Remove(T obj);

        public void Dispose();
    }
}
