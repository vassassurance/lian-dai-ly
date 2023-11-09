using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace LianAgentPortal.Models.DbModels
{
    public class LianUser : IdentityUser
    {
        public LianUser() 
        {
            GoogleAuthenticatorSecretCode = Guid.NewGuid().ToString().Split("-")[0];
        }

        public string Fullname { get; set; }
        public string Description { get; set; }

        [ForeignKey("LianAgent")]
        public long? LianAgentId { get; set; }
        public LianAgent LianAgent { get; set; }

        public string GoogleAuthenticatorSecretCode { get; set; }
        public bool IsActivated { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
