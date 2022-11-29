using InspectionAPI.Data;
using InspectionAPI.Data.Entities;

namespace InspectionAPI.DataAccess
{
    public class InspectionRepository : BaseRepository<Inspection>
    {
        public InspectionRepository(DataContext context) : base(context)
        {
        }
    }
}
