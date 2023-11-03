namespace LianAgentPortal.Models.DbModels
{
    public class LianAgent
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string RegistedPhone { get; set; }
        public string Description { get; set; }
        public string AppId { get; set; }
        public string SecretKey { get; set; }
    }
}
