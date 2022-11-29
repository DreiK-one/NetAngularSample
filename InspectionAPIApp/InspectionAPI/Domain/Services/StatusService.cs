using InspectionAPI.Core.Interfaces;
using InspectionAPI.Core.Interfaces.Data;
using InspectionAPI.Data.Entities;

namespace InspectionAPI.Domain.Services
{
    public class StatusService : IStatusService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StatusService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Status GetStatusById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Status> GetStatuses()
        {
            throw new NotImplementedException();
        }

        public Status CreateStatus(Status status)
        {
            throw new NotImplementedException();
        }

        public Status UpdateStatus(Status status)
        {
            throw new NotImplementedException();
        }

        public int DeleteStatus(int id)
        {
            throw new NotImplementedException();
        }


        private bool StatusExists(int id)
        {
            throw new NotImplementedException();
        }
    }
}
