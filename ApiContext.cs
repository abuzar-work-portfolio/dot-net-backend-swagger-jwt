using Microsoft.EntityFrameworkCore;
using MinimalJwt.Models;
using System.Collections.Generic;


namespace MinimalJwt
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
    }
}
