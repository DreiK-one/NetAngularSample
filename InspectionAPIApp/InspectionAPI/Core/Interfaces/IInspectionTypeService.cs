using InspectionAPI.Data.Entities;


namespace InspectionAPI.Core.Interfaces
{
    public interface IInspectionTypeService
    {
        IEnumerable<InspectionType> GetInspectionTypes();
        InspectionType GetInspectionTypeById(int id);
        InspectionType CreateInspectionType(InspectionType inspectionType);
        InspectionType UpdateInspectionType(InspectionType inspectionType);
        int DeleteInspectionType(int id);
    }
}
