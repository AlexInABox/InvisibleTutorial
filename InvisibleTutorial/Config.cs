using System.ComponentModel;

namespace InvisibleTutorial;

public class Config
{
    public bool Debug { get; set; } = false;

    [Description("The ID of the keybind setting. This should be unique for each plugin.")]
    public int KeybindId { get; set; } = 300;
}