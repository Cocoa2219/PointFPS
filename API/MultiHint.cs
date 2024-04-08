using System.Collections.Generic;
using Exiled.API.Features;
using MEC;

namespace PointFPS.API;

public class MultiHint
{
    public static readonly Dictionary<string, List<string>> playerHint = new();

    public static IEnumerator<float> AddPlayerHint(string playerId, int time, string text)
    {
        var player = Player.Get(playerId);
        var writtenText = string.Empty;

        if (!playerHint.ContainsKey(playerId))
            playerHint.Add(playerId, []);

        writtenText += "<size=25>";
        writtenText += text;
        writtenText += "</size>";
        writtenText += "\n";

        if (playerHint[playerId].Count > 0)
            for (var i = playerHint[playerId].Count - 1; i >= 0; i--)
            {
                writtenText += "<size=25>";
                writtenText += playerHint[playerId][i];
                writtenText += "</size>";
                writtenText += "\n";
            }

        var lineCount = 25;

        lineCount -= 2;
        lineCount -= playerHint[playerId].Count;

        for (var i = 0; i < lineCount; i++)
        {
            writtenText += "<size=25>\n</size>";
        }

        playerHint[playerId].Add(text);
        player.ShowHint(writtenText, 120);
        yield return Timing.WaitForSeconds(time);
        playerHint[playerId].Remove(text);
        RefreshHint(player);
    }

    private static void RefreshHint(Player player)
    {
        var text = string.Empty;

        if (playerHint[player.UserId].Count > 0)
            for (var i = playerHint[player.UserId].Count - 1; i >= 0; i--)
            {
                text += "<size=25>";
                text += playerHint[player.UserId][i];
                text += "</size>";
                text += "\n";
            }

        var lineCount = 25;

        lineCount -= 1;
        lineCount -= playerHint[player.UserId].Count;

        for (var i = 0; i < lineCount; i++)
        {
            text += "<size=25>\n</size>";
        }

        player.ShowHint(text, 120);
    }
}