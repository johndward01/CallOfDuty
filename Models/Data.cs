namespace CallOfDuty.Models
{
    public class Data
    {
        public string title { get; set; }
        public string platform { get; set; }
        public string username { get; set; }
        public string type { get; set; }
        public int level { get; set; }
        public int maxLevel { get; set; }
        public int levelXpRemainder { get; set; }
        public int levelXpGained { get; set; }
        public int prestige { get; set; }
        public int prestigeId { get; set; }
        public int maxPrestige { get; set; }
        public int totalXp { get; set; }
        public int paragonRank { get; set; }
        public int paragonId { get; set; }
        public int s { get; set; }
        public int p { get; set; }
        public Lifetime lifetime { get; set; }
        public Weekly weekly { get; set; }
        public object engagement { get; set; }
    }
}
