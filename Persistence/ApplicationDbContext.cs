
using Core;
using Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public partial class ApplicationDbContext : IdentityDbContext<AspNetUser, AspNetRole, int, IdentityUserClaim<int>
         , AspNetUserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public class BloggingContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
        {
            public ApplicationDbContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
                optionsBuilder.UseSqlServer("data source=DESKTOP-MLAEPOO;Initial Catalog=SalesOfPoint; Integrated Security=true");

                return new ApplicationDbContext(optionsBuilder.Options);
            }
        }

        public virtual DbSet<Agent> Agents { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<BranchGallary> BranchGallaries { get; set; }
        public virtual DbSet<Catogery> Catogeries { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<SalesInformation> SalesInformations { get; set; }
        public virtual DbSet<Sattelment> Sattelments { get; set; }
        public virtual DbSet<StoreQuantity> StoreQuantities { get; set; }
        public virtual DbSet<StoreReturned> StoreReturneds { get; set; }
        public virtual DbSet<Story> Stories { get; set; }
        public virtual DbSet<Suplier> Supliers { get; set; }
        public virtual DbSet<Suppliment> Suppliments { get; set; }
        public virtual DbSet<SupplimentInformation> SupplimentInformations { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<Vaucher> Vauchers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\;Database=SalesOfPoint;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AspNetUserRole>(userRole =>

            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });
                userRole.HasOne(ur => ur.Role)
                .WithMany(r => r.AspNetUserRoles)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();

                userRole.HasOne(ur => ur.User)
               .WithMany(r => r.AspNetUserRoles)
               .HasForeignKey(ur => ur.UserId)
               .IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);

        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}