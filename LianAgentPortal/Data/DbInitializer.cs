using LianAgentPortal.Commons;
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
            modelBuilder.Entity<LianAgent>().HasData(SeedLianAgents());
            modelBuilder.Entity<IdentityRole>().HasData(SeedRoles());
            modelBuilder.Entity<LianUser>().HasData(SeedAdminUsers());
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(SeedUserRole());
        }


        private List<LianAgent> SeedLianAgents()
        {
            List<LianAgent> agents = new List<LianAgent>();
            agents.Add(new LianAgent() { 
                Id = 1,
                AppId = "27472747",
                Description = "VASS - SANDBOX",
                RegistedPhone = "0962473427",
                Name = "VASS - SANDBOX",
                SecretKey = "3af4df1274fcf5b2ecfe2098e00facf7"
            });
            return agents;
        }

        private List<LianUser> SeedAdminUsers()
        {
            List<LianUser> result = new List<LianUser>();
            LianUser userAdminIt = new LianUser
            {
                Id = AuthenticatorConstants.ADMIN_USER_ID,
                UserName = "0962473427",
                NormalizedUserName = "0962473427",
                Email = "0962473427",
                NormalizedEmail = "0962473427",
                PhoneNumber = "",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = new Guid().ToString("D"),
                GoogleAuthenticatorSecretCode = "ABB80D77",
                IsActivated = true,
                LianAgentId = 1
            };
            userAdminIt.PasswordHash = Functions.HashPassword(userAdminIt, "FE3EB4DF");
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

        private List<IdentityUserRole<string>> SeedUserRole()
        {
            List<IdentityUserRole<string>> result = new List<IdentityUserRole<string>>();
            result.Add(new IdentityUserRole<string>() { 
                RoleId = AuthenticatorConstants.ADMIN_ROLE_ID,
                UserId = AuthenticatorConstants.ADMIN_USER_ID
            });
            return result;
        }

    }
}
