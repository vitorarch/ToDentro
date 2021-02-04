using API.Models.Companies.Jobs.AdditionalInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Models.Companies.Jobs
{
    public class Job
    {
        public Guid JobId { get; set; }

        public string CompanyId { get; set; }

        [MaxLength(15)]
        public string Position { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        [MaxLength(25)]
        public string PayRange { get; set; }

        [MaxLength(20)]
        public string Category { get; set; }

    }
}
