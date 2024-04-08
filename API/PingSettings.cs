namespace PointFPS.API;

public class PingSettings
{
    public int PingCooldown { get; set; } = 1;
    public int PingDuration { get; set; } = 5;
    public int PingLimit { get; set; } = 5;
}