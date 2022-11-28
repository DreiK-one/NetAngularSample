using InspectionAPI.Core.Interfaces.Data;
using InspectionAPI.Data.Entities;

namespace InspectionAPI.DataAccess
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        public Task Add(T obj)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Remove(T obj)
        {
            throw new NotImplementedException();
        }

        public Task Update(T obj)
        {
            throw new NotImplementedException();
        }
    }
}
