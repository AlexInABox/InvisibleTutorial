namespace InvisibleTutorial.Events
{
    using UserSettings.ServerSpecific;
    using Exiled.API.Features.Roles;
    using Exiled.API.Features;
    using PlayerRoles;
    using System.Numerics;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;


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

        private readonly HashSet<int> _invisiblePlayers = new();

        private void ToggleInvisibility(Player player)
        {
            Log.Debug("Trying to toggle invisibility for player!");

            if (player.Role is FpcRole fpc && player.Role == RoleTypeId.Tutorial)
            {
                var filteredListOfPlayers = Player.List.Where(x => x != player).ToList();

                if (_invisiblePlayers.Contains(player.Id))
                {
                    // Player is already invisible; remove from the list and reset scale
                    _invisiblePlayers.Remove(player.Id);
                    player.SetFakeScale(new UnityEngine.Vector3(1, 1, 1), filteredListOfPlayers);
                    //player.SetFakeScale(player.Scale, filteredListOfPlayers);
                    Log.Debug($"Player {player.Id} is now visible.");
                }
                else
                {
                    // Player is not invisible; add to the list and set scale to 0
                    _invisiblePlayers.Add(player.Id);
                    player.SetFakeScale(new UnityEngine.Vector3(0, 0, 0), filteredListOfPlayers);
                    Log.Debug($"Player {player.Id} is now invisible.");
                }
            }
        }

    }
}
