using System.ComponentModel;

namespace InvisibleTutorial;

public class Translation
{
    [Description("The label for the keybind setting")]
    public string KeybindSettingLabel { get; set; } = "Unsichtbarkeit als Tutorial aktivieren";

    [Description("The hint description for the keybind setting")]
    public string KeybindSettingHintDescription { get; set; } =
        "Drücke die Taste, um unsichtbar zu werden. Drücke sie erneut, um sichtbar zu werden.";

    [Description("Header text for the spray settings group")]
    public string TemplateGroupHeader { get; set; } = "(ADMIN) Invisible Tutorial";

    [Description("Hint displayed when a player goes invisible.")]
    public string InvisibilityEnabled { get; set; } = "<b><color=green>Du bist jetzt unsichtbar!</color></b>";

    [Description("Hint displayed when a player is visible again.")]
    public string InvisibilityDisabled { get; set; } = "<b><color=red>Du bist nicht mehr unsichtbar!</color></b>";
    
    [Description("Message displayed when a player lacks permission to use the feature.")]
    public string NoPermission { get; set; } = "<b><color=red>Du hast keine Berechtigung, diese Funktion zu nutzen!</color></b>";
}