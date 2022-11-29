using InspectionAPI.Data.Entities;


namespace InspectionAPI.Core.Interfaces
{
    public interface IInspectionService
    {
        IEnumerable<Inspection> GetInspections();
        Inspection GetInspectionById(int id);
        Inspection CreateInspection(Inspection inspection);
        Inspection UpdateInspection(Inspection inspection);
        int DeleteInspection(int id);
    }
}
