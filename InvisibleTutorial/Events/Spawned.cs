namespace InvisibleTutorial.Events
{
    using Exiled.Events.EventArgs.Player;
    using PlayerRoles;
    using System.Linq;

    internal sealed class Spawned
    {
        private SettingValueReceived settingValueReceived;
        public Spawned(SettingValueReceived settingValueReceived)
        {
            this.settingValueReceived = settingValueReceived;
        }
        public void OnSpawned(SpawnedEventArgs ev)
        {
            if (settingValueReceived._invisiblePlayers.Contains(ev.Player.Id) && ev.Player.Role != RoleTypeId.Tutorial)
                settingValueReceived.MakeVisible(ev.Player);
        }
    }
}
