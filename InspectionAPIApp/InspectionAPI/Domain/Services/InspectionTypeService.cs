using InspectionAPI.Core.Interfaces;
using InspectionAPI.Core.Interfaces.Data;
using InspectionAPI.Data.Entities;

namespace InspectionAPI.Domain.Services
{
    public class InspectionTypeService : IInspectionTypeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public InspectionTypeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public InspectionType GetInspectionTypeById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<InspectionType> GetInspectionTypes()
        {
            throw new NotImplementedException();
        }

        public InspectionType CreateInspectionType(InspectionType inspectionType)
        {
            throw new NotImplementedException();
        }

        public InspectionType UpdateInspectionType(InspectionType inspectionType)
        {
            throw new NotImplementedException();
        }

        public int DeleteInspectionType(int id)
        {
            throw new NotImplementedException();
        }
    

        private bool InspectionTypeExists(int id)
        {
            throw new NotImplementedException();
        }  
    }
}
