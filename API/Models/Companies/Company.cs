using API.Models.Advertisements;
using API.Models.Companies.Jobs;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Models.Companies
{
    public class Company
    {
        [Required]
        [MaxLength(18)]
        public string Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(13)]
        public string Phone { get; set; }

        [MaxLength(40)]
        public string Email { get; set; }

        [Required]
        [MaxLength(70)]
        public string Adress { get; set; }

        [Required]
        public int Number { get; set; }

        [MaxLength(20)]
        public string Complement { get; set; }

        [Required]
        [MaxLength(20)]
        public string Neighborhood { get; set; }

        [Required]
        [MaxLength(20)]
        public string State { get; set; }

        [Required]
        [MaxLength(20)]
        public string City { get; set; }

        [Required]
        [MaxLength(9)]
        public string CEP { get; set; }

        [Required]
        [MaxLength(25)]
        public string Type { get; set; }

        [Required]
        [MaxLength(25)]
        public string Description { get; set; }

        [Required]
        [MaxLength(100)]
        public string Observations { get; set; }

        [Required]
        [MaxLength(25)]
        public string Sector { get; set; }

        public string Photo { get; set; }

        [Required]
        [MaxLength(20)]
        public string Role { get; set; }

        //[Required]
        //[MaxLength(50)]
        //public string Password { get; set; }

    }
}
