using Exiled.API.Features;
using Exiled.API.Enums;


using Exiled.Events.EventArgs.Player;

namespace Exiled.LCZLockEvents
{
    using Exiled.Events.EventArgs.Server;
    using LCZLock;
    using MEC;

    internal sealed class RoundHandler
    {
        private readonly LCZLock Instance = LCZLock.Instance;
        public void OnRoundStarted()
        {
            IEnumerable<Door> allDoors = Door.List;
       
            foreach (var door in allDoors)
            {
                if ((door.Type == DoorType.ElevatorLczA || door.Type == DoorType.ElevatorLczB) && !door.IsLocked)
                {
                    door.Lock(Instance.Config.TimeUntilUnlock, DoorLockType.AdminCommand);
                }
            }
            if (Instance.Config.DoLockCassieMessage)
            {
                Timing.RunCoroutine(LockElevatorsMessage(Instance.Config.LockCassieTime), "lockLczElevators");
            }
            if (Instance.Config.DoUnlockCassieMessage)
            {
                Timing.RunCoroutine(UnlockElevatorsMessage(Instance.Config.TimeUntilUnlock), "unlockLczElevators");
            }
        }

        public void OnRoundEnded(RoundEndedEventArgs ev)
        {
            Timing.KillCoroutines("unlockLczElevators");
            Timing.KillCoroutines("lockLczElevators");
        }
        private IEnumerator<float> UnlockElevatorsMessage(float waitSeconds)
        {
            yield return Timing.WaitForSeconds(waitSeconds);

            if (Instance.Config.DoUnlockCassieMessage)
            {
                Cassie.MessageTranslated(Instance.Config.UnlockCassieMessage, Instance.Config.UnlockSubtitles, true, false, true); // message, subtitles, hold, not noisy, do subtitles
            };
        }
        private IEnumerator<float> LockElevatorsMessage(float waitSeconds)
        {
            yield return Timing.WaitForSeconds(waitSeconds);

            if (Instance.Config.DoUnlockCassieMessage)
            {
                Cassie.MessageTranslated(Instance.Config.LockCassieMessage, Instance.Config.LockSubtitles, true, false, true);
            };
        }
    }
}
