using Exiled.API.Features;
using Server = Exiled.Events.Handlers.Server;

namespace P106HomeOpenFF
{
    public class P106HomeOpenFF : Plugin<Configs>
    {
        public static P106HomeOpenFF P106HomeOpenFFRef;
        public override string Prefix => "P106HomeOpenFF";

        private EventHandler eventHandlers;

        public override void OnEnabled()
        {
            P106HomeOpenFFRef = this;
            eventHandlers = new EventHandler();

            Server.RoundStarted += eventHandlers.OnRoundStarted;
            Server.RoundEnded += eventHandlers.OnRoundEnded;

            base.OnEnabled();
        }
        public override void OnDisabled()
        {
            Server.RoundEnded -= eventHandlers.OnRoundEnded;
            Server.RoundStarted -= eventHandlers.OnRoundStarted;
            eventHandlers = null;
            P106HomeOpenFFRef = null;
            base.OnDisabled();
        }
    }
}