using LianAgentPortal.Models.DbModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace LianAgentPortal.Data
{
    public class ApplicationDbContext : IdentityDbContext<LianUser>
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
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            modelBuilder.Entity<InsuranceMaster>()
                .Property(e => e.Id)
                .UseIdentityColumn(seed: 1001, increment: 1);

            base.OnModelCreating(modelBuilder);
            new DbInitializer(modelBuilder).Seed();
        }

        public override DbSet<LianUser> Users { get; set; }
        public DbSet<LianAgent> LianAgents { get; set; }

        public DbSet<InsuranceMaster> InsuranceMasters { get; set; }
        public DbSet<InsuranceFamilyBreadwinnerDetail> InsuranceFamilyBreadwinnerDetails { get; set; }
        public DbSet<InsuranceMotorDetail> InsuranceMotorDetails { get; set; }
        public DbSet<InsurancePersonalAccidentDetail> InsurancePersonalAccidentDetails { get; set; }

    }
}
