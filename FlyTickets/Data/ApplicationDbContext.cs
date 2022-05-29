using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FlyTickets.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Route> Routes { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(LocalDb)\\MSSQLLocalDB;Database=FlyTickets;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            string ADMIN_ID = "02174cf0–9412–4cfe - afbf - 59f706d72cf6";
            string ROLE_ID = "341743f0 - asd2–42de - afbf - 59kmkkmk72cf6";

            //seed admin role
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "Admin",
                Id = ROLE_ID,
                ConcurrencyStamp = ROLE_ID
            },
            new IdentityRole
            {
                Name = "User",
                NormalizedName="User"
            });


            //create user
            var appUser = new IdentityUser
            {
                Id = ADMIN_ID,
                Email = "admin@abv.com",
                EmailConfirmed = true,
                UserName = "admin@abv.com",
                NormalizedEmail = "admin@abv.COM",
                NormalizedUserName = "admin@abv.COM"
            };

            //set user password
            PasswordHasher<IdentityUser> ph = new PasswordHasher<IdentityUser>();
            appUser.PasswordHash = ph.HashPassword(appUser, "admin!2");

            //seed user
            builder.Entity<IdentityUser>().HasData(appUser);

            //set user role to admin
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });
        }
        public ApplicationDbContext()
        {
            this.Database.EnsureCreated();
        }
    }
}
