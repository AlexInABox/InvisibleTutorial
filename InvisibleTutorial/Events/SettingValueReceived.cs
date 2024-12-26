namespace InvisibleTutorial.Events
{
    using UserSettings.ServerSpecific;
    using Exiled.API.Features.Roles;
    using Exiled.API.Features;
    using PlayerRoles;
    using System.Numerics;

    internal sealed class SettingValueReceived
    {
        private readonly Config _config;
        public void OnSettingValueReceived(ReferenceHub hub, ServerSpecificSettingBase settingBase)
        {
            Log.Debug("Received hotkey!");
            if (!Player.TryGet(hub, out Player player))
                return;

            if (settingBase is SSKeybindSetting keyindSetting && keyindSetting.SettingId == InvisibleTutorial.Instance.Config.KeybindId && keyindSetting.SyncIsPressed)
            {
                ToggleInvisibility(player);
            }
        }

        private void ToggleInvisibility(Player player)
        {
            Log.Debug("Trying to toggle invisibility for player!");
            if (player.Role is FpcRole fpc && player.Role == RoleTypeId.Tutorial)
            {
                //fpc.IsInvisible = !fpc.IsInvisible;
                player.SetFakeScale(new Vector3(0, 0, 0), Player.List.Except([player]));
                Log.Debug("Toggled invisibility for player!");
            }
        }
    }
}
