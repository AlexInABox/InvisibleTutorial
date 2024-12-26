namespace InvisibleTutorial.Events
{
    using UserSettings.ServerSpecific;
    using Exiled.Events.EventArgs.Player;

    internal sealed class Verified
    {
        public void OnVerified(VerifiedEventArgs ev)
        {
            ServerSpecificSettingsSync.SendToPlayer(ev.Player.ReferenceHub);
        }
    }
}
