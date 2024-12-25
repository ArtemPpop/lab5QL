using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace lab5.Models
{
    public class Attendance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AttendanceId { get; set; }
        [Required]
        [ForeignKey("StudentId")]
        public int StudentId { get; set; }
        public Student? Student { get; set; }
        public DateTime? Date { get; set; }
        [Required]
        public bool IsPresent { get; set; }
       
    }
}
