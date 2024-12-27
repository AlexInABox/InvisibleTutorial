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
        //public Hint InvisibilityEnabled { get; private set; } = new("<b>You <color=green>are</color> now invisible.</b>", 3);
        public string InvisibilityEnabled { get; private set; } = "<b>You <color=green>are</color> now invisible.</b>"

        [Description("Hint displayed when a player is visible again.")]
        //public Hint InvisibilityDisabled { get; private set; } = new("<b>You <color=red>are not</color> invisible anymore.</b>", 3);
        public string InvisibilityDisabled { get; private set; } = "<b>You <color=red>are not</color> invisible anymore.</b>"

        [Description("The unique id of the setting.")]
        public int KeybindId { get; set; } = 201;
    }
}