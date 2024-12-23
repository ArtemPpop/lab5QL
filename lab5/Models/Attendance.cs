﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace lab5.Models
{
    public class Attendance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long AttendanceId { get; set; }
        [Required]
        [ForeignKey("StudentId")]
        public long StudentId { get; set; }
        public Student Student { get; set; }
        public DateTime Date { get; set; }
        public bool IsPresent { get; set; }
       
    }
}
