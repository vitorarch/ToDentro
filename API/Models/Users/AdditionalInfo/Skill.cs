using System;
using System.ComponentModel.DataAnnotations;

namespace API.Models.Users.AdditionalInfo
{
    public class Skill
    {
        public Guid Id { get; set; }

        public Guid ResumeId { get; set; }

        [MaxLength(14)]
        public string UserId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Knowledge { get; set; }
    }
}
