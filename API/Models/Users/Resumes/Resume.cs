using API.Models.Users.AdditionalInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Models.Users.Resumes
{
    public class Resume
    {
        public Guid Id { get; set; }

        [MaxLength(14)]
        public string UserId { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }


    }
}
