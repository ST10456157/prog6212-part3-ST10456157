using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using prog6212_part3_ST10456157.Models;


    namespace prog6212_part3_ST10456157.Data
    {
        public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options) { }

            public DbSet<LecturerClaim> Claims { get; set; }
        }
    }

