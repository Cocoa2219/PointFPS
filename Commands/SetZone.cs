using System;
using System.Diagnostics.CodeAnalysis;
using CommandSystem;
using Exiled.API.Enums;

namespace PointFPS.Commands;

[CommandHandler(typeof(RemoteAdminCommandHandler))]
public class SetZone : ICommand
{
    public bool Execute(ArraySegment<string> arguments, ICommandSender sender, [UnscopedRef] out string response)
    {
        switch (arguments.At(0).ToLower()[0])
        {
            case 'l':
                PointFPS.Instance._eventHandler.ZoneType = ZoneType.LightContainment;
                break;
            case 'h':
                PointFPS.Instance._eventHandler.ZoneType = ZoneType.HeavyContainment;
                break;
            case 'e':
                PointFPS.Instance._eventHandler.ZoneType = ZoneType.Entrance;
                break;
            default:
                response = "Unknown ZoneType.";
                return false;
        }

        response = $"ZoneType = {PointFPS.Instance._eventHandler.ZoneType}";
        return true;
    }

    public string Command { get; } = "setzone";
    public string[] Aliases { get; } = ["sz"];
    public string Description { get; } = "Set the zone type.";
}