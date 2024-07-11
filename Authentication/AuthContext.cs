using Authentication.Entities;
using Microsoft.EntityFrameworkCore;

namespace Authentication
{
    public class AuthContext : DbContext
    {

        public AuthContext(DbContextOptions<AuthContext> options): base(options) 
        {
            
        }
        public DbSet<MissionDto> Missions{get;set;}
        public DbSet<User> Users { get; set; }
        public DbSet<Themess> Themess { get; set; }
        public DbSet<Skill> Skills { get; set; }
    }
    
}
