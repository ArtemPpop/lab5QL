﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http.HttpResults;

namespace lab5.Models
{
    public class Grade
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GradeId { get; set; }
        [Required]
        public int Value { get; set; }
        [ForeignKey("StudentId")]
        public int StudentId { get; set; }
        public Student? Student { get; set; }
        [ForeignKey("SubjectId")]
        public int SubjectId { get; set; }
        public Subject? Subject { get; set; }
        [ForeignKey("TeacherId")]
        public int TeacherId { get; set; }
        public Teacher? Teacher { get; set; }
        public DateTime? CreateAt { get; set; }
        public Grade()
        {
            CreateAt = DateTime.Now;
        }
    }
}
