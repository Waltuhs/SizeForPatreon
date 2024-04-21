using Exiled.API.Features;
using System;
using SizeForPatreon;


namespace KillCounter
{
    public class Plugin : Plugin<Config>
    {
        public static Plugin Instance { get; private set; } = null;
        public override string Author => "sexy waltuh";
        public override string Name => ".size";
        public override string Prefix => ".size";
        public override Version Version => new Version(1, 0, 0);

        public override void OnEnabled()
        {
            base.OnEnabled();
            Instance = this;
        }


        public override void OnDisabled()
        {
            base.OnDisabled();
            Instance = null;
        }
    }
}