using InspectionAPI.Core.Interfaces.Data;
using InspectionAPI.Data;
using InspectionAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace InspectionAPI.DataAccess
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly DataContext _context;
        private readonly DbSet<T> DbSet;

        public BaseRepository(DataContext context)
        {
            _context = context;
            DbSet = context.Set<T>();
        }


        public virtual IQueryable<T> GetAll()
        {
            return DbSet;
        }

        public async Task<T> GetById(int id)
        {
            return await DbSet.AsNoTracking()
                .FirstOrDefaultAsync(entity => entity.Id == id);
        }

        public async Task Add(T obj)
        {
            await DbSet.AddAsync(obj);
        }

        public virtual async Task Remove(int id)
        {
            DbSet.Remove(await DbSet.FindAsync(id));
        }

        public virtual async Task Update(T obj)
        {
            DbSet.Update(obj);
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
