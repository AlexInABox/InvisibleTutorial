namespace InvisibleTutorial
{
    using System.ComponentModel;
    using System.IO;
    using System.Collections.Generic;

    using Exiled.API.Features;
    using Exiled.API.Interfaces;

    using Enums;


    /// <inheritdoc cref="IConfig"/>
    public sealed class Config : IConfig
    {
        public Config()
        {
        }
        /// <inheritdoc/>
        public bool IsEnabled { get; set; } = true;

        /// <inheritdoc />
        public bool Debug { get; set; }

        [Description("Hint displayed when a player goes invisible.")]
        public Message InvisibilityEnabled { get; set; } = new()
        {
            Content = "<b>You <color=green>are</color> now invisible.</b>",
            Duration = 3f,
            Show = true,
        };

        [Description("Hint displayed when a player is visible again.")]
        public Message InvisibilityDisabled { get; set; } = new()
        {
            Content = "<b>You <color=red>are not</color> invisible anymore.</b>",
            Duration = 3f,
            Show = true,
        };

        [Description("The unique id of the setting.")]
        public int KeybindId { get; set; } = 201;
    }
}