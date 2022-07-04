using System.ComponentModel.DataAnnotations;

namespace CatalogueGQL.Shared.Models
{
    public class Major
    {
        public int Id { get; set; }
        public decimal MinCreditHours { get; set; }
        [Required]
        [StringLength(10)]
        public String Code { get; set; }
        [Required]
        [StringLength(100)]
        public String Title { get; set; }
        public ICollection<Courses> Courses { get; set; } = new List<Courses>();
    }
}
