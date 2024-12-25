using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;

namespace lab5.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public int NumberClass { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public ICollection<Grade>? Grades { get; set; }
        public ICollection<Attendance>? Attendances { get; set; }
       
    }
}
