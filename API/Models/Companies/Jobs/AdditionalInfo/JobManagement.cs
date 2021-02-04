using API.Models.Users;
using System;
using System.ComponentModel.DataAnnotations;

namespace API.Models.Companies.Jobs.AdditionalInfo
{
    public class JobManagement
    {

        [Key]
        [MaxLength(18)]
        public string UserId { get; set; }

        public Guid JobId { get; set; }
    }
}
