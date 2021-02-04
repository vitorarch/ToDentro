using System;
using System.ComponentModel.DataAnnotations;

namespace API.Models.Companies.Jobs.AdditionalInfo
{
    public class Requirement
    {

        public Guid Id { get; set; }

        [MaxLength(40)]
        public string Requesite { get; set; }
        public Guid JobId { get; set; }
    }
}
