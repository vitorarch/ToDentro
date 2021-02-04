using System;
using System.ComponentModel.DataAnnotations;

namespace API.Models.Users.AdditionalInfo
{
    public class Education
    {

        public Guid Id { get; set; }

        [MaxLength(14)]
        public string UserId { get; set; }

        public Guid ResumeId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Institution { get; set; }

        [Required]
        [MaxLength(50)]
        public string Degree { get; set; }

        [Required]
        [MaxLength(50)]
        public string FieldOfStudy { get; set; }

        [Required]
        [MaxLength(50)]
        public string StartDate { get; set; }


        [MaxLength(50)]
        public string? EndDate { get; set; }



    }
}
