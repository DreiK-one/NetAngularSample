using InspectionAPI.Core.Interfaces.Data;
using InspectionAPI.Data;
using InspectionAPI.Data.Entities;

namespace InspectionAPI.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        private readonly IBaseRepository<Inspection> _inspectionRepository;
        private readonly IBaseRepository<InspectionType> _inspectionTypeRepository; 
        private readonly IBaseRepository<Status> _statusRepository;

        public UnitOfWork(DataContext context, 
            IBaseRepository<Inspection> inspectionRepository,
            IBaseRepository<InspectionType> inspectionTypeRepository,
            IBaseRepository<Status> statusRepository)
        {
            _context = context;
            _inspectionRepository = inspectionRepository;
            _inspectionTypeRepository = inspectionTypeRepository;
            _statusRepository = statusRepository;          
        }

        public IBaseRepository<Inspection> Inspections => _inspectionRepository;
        public IBaseRepository<InspectionType> InspectionTypes => _inspectionTypeRepository;
        public IBaseRepository<Status> Statuses => _statusRepository;

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
            GC.SuppressFinalize(this);
        }    
    }
}
