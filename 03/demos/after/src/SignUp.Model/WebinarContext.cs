using SignUp.Entities;
using System.Data.Entity;

namespace SignUp.Model
{
    public class WebinarContext : DbContext
    {
        public WebinarContext() : base("WebinarContext") { }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Interest> Interests { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Viewer> Viewers { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Entity<Viewer>()
                   .HasOptional(v => v.Country)
                   .WithMany()
                   .HasForeignKey(v => v.CountryId);

            builder.Entity<Viewer>()
                   .HasOptional(v => v.Role)
                   .WithMany()
                   .HasForeignKey(v => v.RoleId);
            
            builder.Entity<Viewer>()
                   .HasMany(v => v.Interests)
                   .WithMany()
                   .Map(m =>
                   {
                       m.ToTable("ViewerInterests");
                       m.MapLeftKey("ViewerId");
                       m.MapRightKey("InterestId");
                   }); ;
        }        
    }
}
