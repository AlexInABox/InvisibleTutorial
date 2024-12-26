namespace InvisibleTutorial
{
    using System.ComponentModel;
    using System.IO;
    using System.Collections.Generic;

    using Exiled.API.Features;
    using Exiled.API.Interfaces;

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
        public Hint InvisibilityEnabled { get; private set; } = new("<b>You <color=green>are</color> now invisible.</b>", 3);

        [Description("Hint displayed when a player is visible again.")]
        public Hint InvisibilityEnabled { get; private set; } = new("<b>You <color=red>are not</color> invisible anymore.</b>", 3);

        [Description("The unique id of the setting.")]
        public int KeybindId { get; set; } = 201;
    }
}