using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UsuariosAPI.Models;

namespace UsuariosAPI.Data
{
    
    public class UserDbContext : IdentityDbContext<CustomIdentityUser, IdentityRole<int>, int>
    {
        private IConfiguration _config;

        public UserDbContext(DbContextOptions<UserDbContext> opt, IConfiguration config) : base(opt)
        {
            _config = config;
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            CustomIdentityUser admin = new CustomIdentityUser
            {
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "caiohds2020@gmail.com",
                NormalizedEmail = "CAIOHDS2020@GMAIL.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                Id = 999
            };
            PasswordHasher<CustomIdentityUser> hasher = new PasswordHasher<CustomIdentityUser>();
            
            admin.PasswordHash = hasher.HashPassword(admin, _config.GetValue<string>("admininfo:password"));
            builder.Entity<CustomIdentityUser>().HasData(admin);

            builder.Entity<IdentityRole<int>>().HasData(new IdentityRole<int>
            { Id = 999, Name = "admin", NormalizedName = "ADMIN" });
           
            builder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int> { RoleId = 999, UserId = 999 });
            builder.Entity<IdentityRole<int>>().HasData(new IdentityRole<int>
            { Id = 150, Name = "regular", NormalizedName = "REGULAR" });

        }
    }
}
