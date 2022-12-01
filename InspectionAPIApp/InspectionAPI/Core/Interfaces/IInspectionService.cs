using InspectionAPI.Data.Entities;


namespace InspectionAPI.Core.Interfaces
{
    public interface IInspectionService
    {
        Task<IEnumerable<Inspection>> GetInspections();
        Task<Inspection> GetInspectionById(int id);
        Task<int> CreateInspection(Inspection inspection);
        Task<int> UpdateInspection(Inspection inspection);
        Task<int> DeleteInspection(int id);
    }
}
