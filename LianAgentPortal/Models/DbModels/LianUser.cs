using Microsoft.AspNetCore.Identity;

namespace LianAgentPortal.Models.DbModels
{
    public class LianUser : IdentityUser
    {
        public LianUser() 
        {
            GoogleAuthenticatorSecretCode = Guid.NewGuid().ToString().Split("-")[0];
        }

        public string GoogleAuthenticatorSecretCode { get; set; }
        public bool IsActivated { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
