using Exiled.API.Features;
using Exiled.Events.EventArgs;
using Exiled.API.Enums;
using Player = Exiled.API.Features.Player;
using UnityEngine;

namespace P106HomeOpenFF
{
    public class EventHandler
    {
        public void OnRoundStarted()
        {
            ServerConsole.FriendlyFire = false;
            ServerConfigSynchronizer.Singleton.RefreshMainBools();
        }

        public void OnRoundEnded(RoundEndedEventArgs ev)
        {
            foreach (Door doorVariant in Map.Doors)
            {
                if (doorVariant.Type == DoorType.Scp106Bottom)
                {
                    foreach (Player Ply in Player.List)
                    {
                        doorVariant.BreakDoor();
                        var doorPos = doorVariant.Base.transform.position;
                        Ply.Position = new Vector3(doorPos.x, doorPos.y + 1, doorPos.z);
                        ServerConsole.FriendlyFire = true;
                        ServerConfigSynchronizer.Singleton.RefreshMainBools();
                    }
                }
            }
        }
    }
}
