namespace LCZLock
{
    using System.ComponentModel;

    using Exiled.API.Interfaces;

    public sealed class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
         
        public bool Debug { get; set; } = false;

        [Description("How long until the elevators are activated")]
        public float TimeUntilUnlock { get; set; } = 40f;

        public Boolean DoCassieMessage { get; set; } = false;
        public string CassieMessage { get; set; } = "bell_start the lockdown on the light containment zone has ended . elevators are now active bell_end";
        public string Subtitles { get; set; } = "The lockdown on the Light Containment Zone has ended. Elevators are now active.";
    }
}
