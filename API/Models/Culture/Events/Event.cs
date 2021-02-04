using System;
using System.ComponentModel.DataAnnotations;

namespace API.Models.Culture.Events
{
    public class Event
    {

        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Provider { get; set; }

        public string Image { get; set; }

        [Required]
        [MaxLength(150)]
        public string Description { get; set; }

        [Required]
        [MaxLength(30)]
        public string Date { get; set; }

        [Required]
        [MaxLength(100)]
        public string Local { get; set; }

        [MaxLength(25)]
        public string Contact { get; set; }

        [Required]
        [MaxLength(50)]
        public string Category { get; set; }

        [Required]
        [MaxLength(50)]
        public string Subcategory { get; set; }
    }
}
