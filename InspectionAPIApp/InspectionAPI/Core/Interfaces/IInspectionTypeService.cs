using InspectionAPI.Data.Entities;


namespace InspectionAPI.Core.Interfaces
{
    public interface IInspectionTypeService
    {
        Task<IEnumerable<InspectionType>> GetInspectionTypes();
        Task<InspectionType> GetInspectionTypeById(int id);
        Task<int> CreateInspectionType(InspectionType inspectionType);
        Task<int> UpdateInspectionType(InspectionType inspectionType);
        Task<int> DeleteInspectionType(int id);
    }
}
