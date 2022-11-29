using InspectionAPI.Data;
using InspectionAPI.Data.Entities;

namespace InspectionAPI.DataAccess
{
    public class StatusRepository : BaseRepository<Status>
    {
        public StatusRepository(DataContext context) : base(context)
        {
        }
    }
}
