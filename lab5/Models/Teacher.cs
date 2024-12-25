using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace lab5.Models
{
    public class Teacher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeacherId { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Grade>? Grades { get; set; }
        public ICollection<Subject>? Subjects { get; set; }
       
    }
}
