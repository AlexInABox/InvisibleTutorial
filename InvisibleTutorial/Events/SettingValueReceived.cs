namespace InvisibleTutorial.Events
{
    using UserSettings.ServerSpecific;
    using Exiled.API.Features.Roles;
    using Exiled.API.Features;
    using PlayerRoles;

    internal sealed class SettingValueReceived
    {
        public void OnSettingValueReceived(ReferenceHub hub, ServerSpecificSettingBase settingBase)
        {
            Log.Debug("Received hotkey!");
            if (!Player.TryGet(hub, out Player player))
                return;

            if (settingBase is SSKeybindSetting keyindSetting && keyindSetting.SyncIsPressed)
            {
                ToggleInvisibility(player);
            }
        }

        private void ToggleInvisibility(Player player)
        {
            if (player.Role is FpcRole fpc && player.Role == RoleTypeId.Tutorial)
                fpc.IsInvisible = !fpc.IsInvisible;
        }
    }
}
