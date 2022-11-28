using InspectionAPI.Data.Entities;

namespace InspectionAPI.Core.Interfaces.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<Inspection> Inspections { get; }
        IBaseRepository<InspectionType> InspectionTypes { get; }
        IBaseRepository<Status> Statuses { get; }

        Task<int> Save();
    }
}
