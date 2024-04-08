using Exiled.API.Interfaces;
using PointFPS.API;

namespace PointFPS
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;
        public PingSettings PingSettings { get; set; } = new PingSettings();

    }
}