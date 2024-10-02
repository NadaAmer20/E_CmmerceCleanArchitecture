using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using E_Commerce.Data.Entites.Identity;
using E_Commerce.Data.Entites;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
namespace E_Commerce.Infrustructure.Context
{
    public class ApplicationDbContext : IdentityDbContext<User,Role,int,  IdentityUserClaim<int>, IdentityUserRole<int>, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer( "Data Source=.;Initial Catalog=E_Cmmerce1;Integrated Security=True;Connect Timeout=60;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"
);
                    
            }
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<UserCart> UserCarts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImages> Images { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRefreshToken> userRefreshToken { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
