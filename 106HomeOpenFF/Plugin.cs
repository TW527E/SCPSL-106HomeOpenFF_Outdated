using Exiled.API.Features;
using Server = Exiled.Events.Handlers.Server;

namespace P106HomeOpenFF
{
    public class P106HomeOpenFF : Plugin<Configs>
    {
        public override string Prefix => "P106HomeOpenFF";
        public static P106HomeOpenFF Instance;

        private EventHandler eventHandlers;

        public override void OnEnabled()
        {
            Instance = this;
            eventHandlers = new EventHandler(this);

            Server.RoundStarted += eventHandlers.OnRoundStarted;
            Server.RoundEnded += eventHandlers.OnRoundEnded;

            base.OnEnabled();
        }
        public override void OnDisabled()
        {
            Server.RoundEnded -= eventHandlers.OnRoundEnded;
            Server.RoundStarted -= eventHandlers.OnRoundStarted;
            eventHandlers = null;
        }
    }
}