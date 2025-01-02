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

        public readonly HashSet<int> _invisiblePlayers = new();

        private void ToggleInvisibility(Player player)
        {
            Log.Debug("Trying to toggle invisibility for player!");

            if (player.Role == RoleTypeId.Tutorial)
            {
                if (_invisiblePlayers.Contains(player.Id))
                    MakeVisible(player);
                else
                    MakeInvisible(player);
            }
        }

        public void MakeVisible(Player player)
        {
            var filteredListOfPlayers = Player.List.Where(x => x != player).ToList();

            // Player is already invisible; remove from the list and reset scale
            _invisiblePlayers.Remove(player.Id);
            var currentScale = player.Scale;
            player.SetFakeScale(currentScale, filteredListOfPlayers);

            player.ShowHint(InvisibleTutorial.Instance.Config.InvisibilityDisabled);
            Log.Debug($"Player {player.Id} is now visible.");
        }

        private void MakeInvisible(Player player)
        {
            var filteredListOfPlayers = Player.List.Where(x => x != player).ToList();

            // Player is not invisible; add to the list and set scale to 0
            _invisiblePlayers.Add(player.Id);
            player.SetFakeScale(new UnityEngine.Vector3(0, 0, 0), filteredListOfPlayers);

            player.ShowHint(InvisibleTutorial.Instance.Config.InvisibilityEnabled);
            Log.Debug($"Player {player.Id} is now invisible.");
        }
    }
}