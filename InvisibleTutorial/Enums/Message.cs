using System.ComponentModel;

namespace InvisibleTutorial.Enums
{
    public class Message
    {
        [Description("The content of the message.")]
        public string Content { get; set; }

        [Description("The duration of the message.")]
        public float Duration { get; set; }

        [Description("A bool indicating whether to show this message or not.")]
        public bool Show { get; set; }
    }
}