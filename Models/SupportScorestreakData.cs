namespace CallOfDuty.Models
{
    public class SupportScorestreakData
    {
        public Airdrop airdrop { get; set; }
        public RadarDroneOverwatch radar_drone_overwatch { get; set; }
        public ScramblerDroneGuard scrambler_drone_guard { get; set; }
        public Uav uav { get; set; }
        public AirdropMultiple airdrop_multiple { get; set; }
        public DirectionalUav directional_uav { get; set; }
    }
}
