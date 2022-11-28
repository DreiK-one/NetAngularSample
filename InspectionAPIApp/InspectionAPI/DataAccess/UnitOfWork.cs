using InspectionAPI.Core.Interfaces.Data;
using InspectionAPI.Data.Entities;

namespace InspectionAPI.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        public IBaseRepository<Inspection> Inspections => throw new NotImplementedException();

        public IBaseRepository<InspectionType> InspectionTypes => throw new NotImplementedException();

        public IBaseRepository<Status> Statuses => throw new NotImplementedException();

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<int> Save()
        {
            throw new NotImplementedException();
        }
    }
}
