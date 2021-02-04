using System;
using System.ComponentModel.DataAnnotations;

namespace API.Models.Advertisements
{
    public class Advertisement
    {


        public Guid Id { get; set; }

        [MaxLength(18)]
        public string CompanyId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(20000)]
        public string Image { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        [MaxLength(50)]
        public string StartDate { get; set; }

        [MaxLength(50)]
        public string EndDate { get; set; }

        public bool Active { get; set; }
    }

}
