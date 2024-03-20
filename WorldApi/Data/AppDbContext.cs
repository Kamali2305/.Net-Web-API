using Microsoft.EntityFrameworkCore;
using WorldApi.Models;

namespace WorldApi.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        
        {
        
        
        
     
        }


        public DbSet<Country> Countries { get; set; }

        public DbSet<States>States { get; set; }


    }
}
