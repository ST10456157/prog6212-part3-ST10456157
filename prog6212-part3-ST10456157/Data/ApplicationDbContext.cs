using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;


    namespace prog6212_part3_ST10456157.Data
    {
        public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options) { }

            public DbSet<Claim> Claims { get; set; }
        }
    }

