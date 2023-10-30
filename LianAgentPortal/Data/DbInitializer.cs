using LianAgentPortal.Commons.Constants;
using LianAgentPortal.Models.DbModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LianAgentPortal.Data
{
    public class DbInitializer
    {
        private readonly ModelBuilder modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public void Seed()
        {
            modelBuilder.Entity<IdentityRole>().HasData(SeedRoles());
            modelBuilder.Entity<LianUser>().HasData(SeedAdminUsers());
        }

        private List<LianUser> SeedAdminUsers()
        {
            List<LianUser> result = new List<LianUser>();
            LianUser userAdminIt = new LianUser
            {
                Id = "3F41798D-C760-4DBB-9F5E-13F78138D565",
                UserName = "0962473427",
                NormalizedUserName = "0962473427",
                Email = "0962473427",
                NormalizedEmail = "0962473427",
                PhoneNumber = "",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = new Guid().ToString("D"),
                GoogleAuthenticatorSecretCode = "ABB80D77",
                IsActivated = true
            };
            userAdminIt.PasswordHash = PassGenerate(userAdminIt, "FE3EB4DF");
            result.Add(userAdminIt);
            return result;
        }

        private List<IdentityRole> SeedRoles()
        {
            List<IdentityRole> result = new List<IdentityRole>();

            result.Add(new IdentityRole()
            {
                Id = AuthenticatorConstants.ADMIN_ROLE_ID,
                Name = AuthenticatorConstants.ADMIN_ROLE,
                NormalizedName = AuthenticatorConstants.ADMIN_ROLE
            });
            return result;
        }

        public string PassGenerate(LianUser user, string password)
        {
            var passHash = new PasswordHasher<LianUser>();
            return passHash.HashPassword(user, password);
        }
    }
}
