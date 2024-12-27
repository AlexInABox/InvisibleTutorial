namespace InvisibleTutorial.Events
{
    using Exiled.Events.EventArgs.Player;
    using PlayerRoles;
    using System.Linq;

    internal sealed class Spawned
    {
        public void OnSpawned(SpawnedEventArgs ev)
        {
            if (SettingValueReceived._invisiblePlayers.Contains(ev.Player.Id) && ev.Player.Role != RoleTypeId.Tutorial)
                SettingValueReceived.MakeVisible(ev.Player);
        }
    }
}
