using System.ComponentModel.DataAnnotations;

namespace CatalogueGQL.Server.Models
{
    public class BaseEntity
    {
        [StringLength(50)]
        public string SetUser { get; set; }
        public DateTime SetDate { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
