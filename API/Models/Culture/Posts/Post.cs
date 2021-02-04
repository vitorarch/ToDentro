using System;
using System.ComponentModel.DataAnnotations;

namespace API.Models.Culture.Posts
{
    public class Post
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MaxLength(20000)]
        public string Image { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }
    }
}
