using InspectionAPI.Data.Entities;


namespace InspectionAPI.Core.Interfaces
{
    public interface IStatusService
    {
        IEnumerable<Status> GetStatuses();
        Status GetStatusById(int id);
        Status CreateStatus(Status status);
        Status UpdateStatus(Status status);
        int DeleteStatus(int id);
    }
}
