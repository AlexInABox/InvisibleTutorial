using System.Collections.Generic;
using CustomPlayerEffects;
using LabApi.Events.Arguments.PlayerEvents;
using LabApi.Events.Handlers;
using LabApi.Features.Wrappers;
using PlayerRoles;
using UserSettings.ServerSpecific;

namespace InvisibleTutorial;

public static class EventHandlers
{
    private static readonly Dictionary<int, bool> PlayerInvisibilityStates = new();

    public static void RegisterEvents()
    {
        ServerSpecificSettingsSync.ServerOnSettingValueReceived += OnSSSReceived;
        Utils.RegisterKeybinds();

        // Feel free to add more event registrations here
        PlayerEvents.ChangedRole += OnChangedRole;
    }

    public static void UnregisterEvents()
    {
        ServerSpecificSettingsSync.ServerOnSettingValueReceived -= OnSSSReceived;
        PlayerEvents.ChangedRole -= OnChangedRole;
    }

    private static void OnSSSReceived(ReferenceHub hub, ServerSpecificSettingBase ev)
    {
        // Make sure the player actually exists and stuff
        if (!Player.TryGet(hub.networkIdentity, out Player player))
            return;

        // Check if the user actually pressed OUR plugins keybind
        if (ev is not SSKeybindSetting keybindSetting ||
            keybindSetting.SettingId != Plugin.Instance.Config!.KeybindId ||
            !keybindSetting.SyncIsPressed) return;

        // Do something funny
        TogglePlayerInvisibility(player);
    }

    private static void TogglePlayerInvisibility(Player player)
    {
        if (player.Role != RoleTypeId.Tutorial || player.CustomInfo.ToLower() == "deathsquad") return;
        bool isInvisible = false;
        if (PlayerInvisibilityStates.TryGetValue(player.PlayerId, out bool currentState)) isInvisible = currentState;

        if (isInvisible)
        {
            player.DisableEffect<Fade>();
            player.DisableEffect<SilentWalk>();
            player.DisableEffect<Ghostly>();
            PlayerInvisibilityStates[player.PlayerId] = false;
            player.SendHint(Plugin.Instance.Translation.InvisibilityDisabled);
        }
        else
        {
            player.EnableEffect<Fade>(255);
            player.EnableEffect<SilentWalk>(255);
            player.EnableEffect<Ghostly>(255);
            PlayerInvisibilityStates[player.PlayerId] = true;
            player.SendHint(Plugin.Instance.Translation.InvisibilityEnabled);
        }
    }

    private static void OnChangedRole(PlayerChangedRoleEventArgs ev)
    {
        ev.Player.DisableEffect<Fade>();
        ev.Player.DisableEffect<SilentWalk>();
        ev.Player.DisableEffect<Ghostly>();
        PlayerInvisibilityStates[ev.Player.PlayerId] = false;
    }
}