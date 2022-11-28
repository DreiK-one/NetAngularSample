using System.ComponentModel.DataAnnotations;

namespace InspectionAPI.Data.Entities
{
    public class InspectionType : BaseEntity
    {
        [StringLength(20)]
        public string InspectionName { get; set; } = string.Empty;
    }
}
