namespace LCZLock
{
    using System.ComponentModel;

    using Exiled.API.Interfaces;

    public sealed class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
         
        public bool Debug { get; set; } = false;

        [Description("How long until the elevators are activated")]
        public float TimeUntilUnlock { get; set; } = 70f;
        [Description("Whether or not to do a message for the elevators unlocking")]
        public Boolean DoUnlockCassieMessage { get; set; } = false;
        public string UnlockCassieMessage { get; set; } = "bell_start the lockdown on the light containment zone has ended . elevators are now active bell_end";
        public string UnlockSubtitles { get; set; } = "The lockdown on the Light Containment Zone has ended. Elevators are now active.";
        [Description("Whether or not to do a message for the elevators locking at the start of the round")]
        public Boolean DoLockCassieMessage { get; set; } = false;
        [Description("How long to wait at the start of the round before the unlock message is played (seconds)")]
        public float LockCassieTime { get; set; } = 5f;
        public string LockCassieMessage { get; set; } = "bell_start for the safety of personnel, the elevators to the light containment zone are temporarily locked . they will become active shortly bell_end";
        public string LockSubtitles { get; set; } = "For the safety of personnel, the elevators to the Light Containment Zone are temporarily locked. They will become active shortly. ";


    }
}
