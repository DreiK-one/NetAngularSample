using InspectionAPI.Data.Entities;


namespace InspectionAPI.Core.Interfaces
{
    public interface IStatusService
    {
        Task<IEnumerable<Status>> GetStatuses();
        Task<Status> GetStatusById(int id);
        Task<int> CreateStatus(Status status);
        Task<int> UpdateStatus(Status status);
        Task<int> DeleteStatus(int id);
    }
}
