using System;
using System.ComponentModel.DataAnnotations;

namespace API.Models.Users.AdditionalInfo
{
    public class Experience
    {

        public Guid Id { get; set; }

        public Guid ResumeId { get; set; }

        [MaxLength(14)]
        public string UserId { get; set; }

        [Required]
        [MaxLength(40)]
        public string Position { get; set; }

        [Required]
        [MaxLength(30)]
        public string Company { get; set; }

        [Required]
        [MaxLength(50)]
        public string EffectiveDate { get; set; }

        [MaxLength(50)]
        public string ResignationDate { get; set; }

    }
}
