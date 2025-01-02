namespace InvisibleTutorial
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Exiled.API.Enums;
    using Exiled.API.Features;
    using Exiled.Events;
    using Events;
    using UserSettings.ServerSpecific;
    using Exiled.API.Features.Core.UserSettings;


    public class InvisibleTutorial : Plugin<Config>
    {
        public override string Prefix => "InvisibleTutorial";
        public override string Name => "InvisibleTutorial";
        public override string Author => "AlexInABox";
        public override Version Version => new Version(1, 0, 1);

        private static InvisibleTutorial Singleton;
        public static InvisibleTutorial Instance => Singleton;
        private SettingValueReceived settingValueReceived;
        private Verified verified;
        private Spawned spawned;
        public override PluginPriority Priority { get; } = PluginPriority.Last;
        public override void OnEnabled()
        {
            Singleton = this;
            Log.Info("InvisibleTutorial has been enabled!");

            settingValueReceived = new SettingValueReceived();
            verified = new Verified();
            spawned = new Spawned(settingValueReceived);

            HeaderSetting header = new HeaderSetting("InvisibleTutorial");
            IEnumerable<SettingBase> settingBases = new SettingBase[]
            {
                header,
                new KeybindSetting(Config.KeybindId, "Toggle invisibility as Tutorial!", default, hintDescription: "Pressing this keybinding toggles your invisibility when in tutorial!"),
            };

            SettingBase.Register(settingBases);
            SettingBase.SendToAll();

            ServerSpecificSettingsSync.ServerOnSettingValueReceived += settingValueReceived.OnSettingValueReceived;
            Exiled.Events.Handlers.Player.Verified += verified.OnVerified;
            Exiled.Events.Handlers.Player.Spawned += spawned.OnSpawned;

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Log.Info("InvisibleTutorial has been disabled!");

            ServerSpecificSettingsSync.ServerOnSettingValueReceived -= settingValueReceived.OnSettingValueReceived;
            Exiled.Events.Handlers.Player.Verified -= verified.OnVerified;
            Exiled.Events.Handlers.Player.Spawned -= spawned.OnSpawned;

            base.OnDisabled();
        }
    }
}