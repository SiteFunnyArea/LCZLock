namespace LCZLock
{
    using Exiled.API.Enums;
    using Exiled.API.Features;
    using Exiled.LCZLockEvents;

    public class LCZLock : Plugin<Config>
    {
        private RoundHandler? roundHandler;

        public override string Author { get; } = "Rue | Updated By: KadotCom";
        public override string Name { get; } = "LCZLock";
        public override string Prefix { get; } = "LCZLock";
        public override Version Version { get; } = new Version(1, 4, 0);
        public override Version RequiredExiledVersion { get; } = new Version(8, 0, 0);

        public override PluginPriority Priority { get; } = PluginPriority.Last;

        private LCZLock() { }
        private static readonly LCZLock Singleton = new LCZLock();
        public static LCZLock Instance => Singleton;

        public override void OnEnabled()
        {
            roundHandler = new RoundHandler();
            Exiled.Events.Handlers.Server.RoundStarted += roundHandler.OnRoundStarted;
            Exiled.Events.Handlers.Server.RoundEnded += roundHandler.OnRoundEnded;
            base.OnEnabled();
        }
        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Server.RoundStarted -= roundHandler.OnRoundStarted;
            Exiled.Events.Handlers.Server.RoundEnded -= roundHandler.OnRoundEnded;
            roundHandler = null;
            base.OnDisabled();
        }
    }
}
