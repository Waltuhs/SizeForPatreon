using Exiled.API.Interfaces;
using System.ComponentModel;

namespace SizeForPatreon
{
    public sealed class Config : IConfig
    {

        [Description("Is the plugin enabled?")]
        public bool IsEnabled { get; set; } = true;

        [Description("Are debug messages enabled?")]
        public bool Debug { get; set; } = false;

        [Description("Minimum value for X. (dont mind the 0's)")]
        public float MinXvalue { get; set; } = 0.8f;

        [Description("Minimum value for Y. (dont mind the 0's)")]
        public float MinYvalue { get; set; } = 0.8f;

        [Description("Maximum value for X. (dont mind the 0's)")]
        public float MaxXvalue { get; set; } = 1.2f;

        [Description("Maximum value for Y. (dont mind the 0's)")]
        public float MaxYvalue { get; set; } = 1.2f;

    }
}