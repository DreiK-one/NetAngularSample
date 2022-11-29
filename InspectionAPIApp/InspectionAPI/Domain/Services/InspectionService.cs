using InspectionAPI.Core.Interfaces;
using InspectionAPI.Core.Interfaces.Data;
using InspectionAPI.Data.Entities;

namespace InspectionAPI.Domain.Services
{
    public class InspectionService : IInspectionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public InspectionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Inspection GetInspectionById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Inspection> GetInspections()
        {
            throw new NotImplementedException();
        }
        public Inspection CreateInspection(Inspection inspection)
        {
            throw new NotImplementedException();
        }

        public Inspection UpdateInspection(Inspection inspection)
        {
            throw new NotImplementedException();
        }

        public int DeleteInspection(int id)
        {
            throw new NotImplementedException();
        }


        private bool InspectionExists(int id)
        {
            throw new NotImplementedException();
        } 
    }
}
