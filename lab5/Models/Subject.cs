using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab5.Models
{
    public class Subject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long SubjectId { get; set; }
        [Required]
        public string? Name { get; set; }
        public ICollection<Grade> Grades { get; set; }
        
    }
}
