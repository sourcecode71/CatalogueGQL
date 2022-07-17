using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catalogue.Shared.Models
{
    public partial class Course :BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(10)]
        public string Code { get; set; }

        [Required]
        public string Title { get; set; }
        public double CreditHours { get; set; }

        public int SchoolId { get; set; }
        public School School { get; set; }
        
        public Course()
        {
            Title = string.Empty;
            Code = string.Empty;
            School= new School();
        }
    }
}
