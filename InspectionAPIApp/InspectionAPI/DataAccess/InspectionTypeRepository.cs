using InspectionAPI.Data;
using InspectionAPI.Data.Entities;

namespace InspectionAPI.DataAccess
{
    public class InspectionTypeRepository : BaseRepository<InspectionType>
    {
        public InspectionTypeRepository(DataContext context) : base(context)
        {
        }
    }
}
