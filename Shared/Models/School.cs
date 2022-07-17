using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catalogue.Shared.Models
{
    public class School :BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Name { get; set; }
        public ICollection<Course> Course { get; set; }

        public School()
        {
            Title =string.Empty;
            Name =string.Empty;
            Course = new List<Course>();
        }
    }
}
