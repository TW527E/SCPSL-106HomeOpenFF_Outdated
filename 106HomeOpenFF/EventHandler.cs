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
            foreach (Player Ply in Player.List)
            {
                Ply.IsFriendlyFireEnabled = true;
            }
        }

        public void OnRoundEnded(RoundEndedEventArgs ev)
        {
            foreach (Door doorVariant in Map.Doors)
            {
                if (doorVariant.Type == DoorType.Scp106Bottom)
                {
                    foreach (Player Ply in Player.List)
                    {
                        if (P106HomeOpenFF.P106HomeOpenFFRef.Config.Onlyff == true)
                        {
                            Ply.IsFriendlyFireEnabled = true;
                        }
                        else
                        {
                            doorVariant.BreakDoor();
                            var doorPos = doorVariant.Base.transform.position;
                            Ply.Position = new Vector3(doorPos.x, doorPos.y + 1, doorPos.z);
                            Ply.IsFriendlyFireEnabled = true;
                        }
                    }
                }
            }
        }
    }
}
