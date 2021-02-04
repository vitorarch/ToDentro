using API.Models.Advertisements;
using API.Models.Companies.Jobs;
using API.Models.Companies.Jobs.AdditionalInfo;
using API.Models.Culture.Events;
using API.Models.Culture.Posts;
using API.Models.Users.AdditionalInfo;
using Microsoft.EntityFrameworkCore;
using API.Models.Companies;
using API.Models.Users;
using API.Models.Users.Resumes;

namespace API.DataAccess
{
    public class ToDentroContext : DbContext
    {

        public ToDentroContext(DbContextOptions options) : base(options)
        {
        
        }

        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Post> Posts { get; set; }
        
        public DbSet<Company> Companies { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Differential> Differentials { get; set; }
        public DbSet<JobManagement> JobManagements { get; set; }
        public DbSet<Requirement> Requirements { get; set; }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Resume> Resumes { get; set; }
        public DbSet<Education> Education { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Skill> Skills { get; set; }

    }
}
