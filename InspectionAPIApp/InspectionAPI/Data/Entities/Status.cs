using System.ComponentModel.DataAnnotations;

namespace InspectionAPI.Data.Entities
{
    public class Status : BaseEntity
    {
        [StringLength(20)]
        public string StatusOption { get; set; } = string.Empty;
    }
}
