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
        public override Version Version => new Version(1, 0, 0);

        private static InvisibleTutorial Singleton;
        public static InvisibleTutorial Instance => Singleton;
        private SettingValueReceived settingValueReceived;
        private Verified verified;
        public override PluginPriority Priority { get; } = PluginPriority.Last;
        public override void OnEnabled()
        {
            Singleton = this;
            Log.Info("InvisibleTutorial has been enabled!");

            settingValueReceived = new SettingValueReceived();
            verified = new Verified();

            HeaderSetting header = new HeaderSetting("InvisibleTutorial");
            IEnumerable<SettingBase> settingBases = new SettingBase[]
            {
                header,
                new KeybindSetting(Config.KeybindId, "Toggle invisiblity as Tutorial!", default, hintDescription: "Pressing this keybind toggles your invisiblity when in tutorial!"),
            };

            SettingBase.Register(settingBases);
            SettingBase.SendToAll();

            ServerSpecificSettingsSync.ServerOnSettingValueReceived += settingValueReceived.OnSettingValueReceived;
            Exiled.Events.Handlers.Player.Verified += verified.OnVerified;

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Log.Info("InvisibleTutorial has been disabled!");

            ServerSpecificSettingsSync.ServerOnSettingValueReceived -= settingValueReceived.OnSettingValueReceived;
            Exiled.Events.Handlers.Player.Verified -= verified.OnVerified;

            base.OnDisabled();
        }
    }
}