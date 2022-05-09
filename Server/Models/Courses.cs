using System.ComponentModel.DataAnnotations;

namespace CatalogueGQL.Server.Models
{
   
    public class Courses :BaseEntity
    {
        [Key]
        public int Id { get; set; }
      
        [Required]
        [StringLength(10)]
        public string Code { get; set; }
      
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        public double CreditHours { get; set; }
        public int MajorId { get; set; }
        public Major Major { get; set; }
    }
}
