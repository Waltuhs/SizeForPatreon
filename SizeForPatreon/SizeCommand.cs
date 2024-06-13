using Exiled.API.Features;
using System;
using CommandSystem;
using RemoteAdmin;
using SizeForPatreon;
using Exiled.Permissions.Extensions;

namespace SizeForPatreon
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class SizeCommand : ICommand
    {
        public string Command { get; } = "size";
        public string[] Aliases { get; } = new string[] { "sz" };
        public string Description { get; } = "Sets patreon users size inbetween an amount described in config";
        public string Permission { get; } = "SizeForPatreon.size.set";
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player player = Player.Get(sender);

            if (!(sender is PlayerCommandSender playerSender))
            {
                response = "Command must be executed by a player";
                return false;
            }

            if (!Round.IsStarted)
            {
                response = "You cannot execute this command unless the round has started!";
                return false;
            }

            if (!playerSender.CheckPermission(Permission)) 
            {
                response = "You don't have permission to use this command";
                return false;
            }

            if (arguments.Count != 2)
            {
                response = "Usage: size <x> <y>";
                return false;
            }

            if (!float.TryParse(arguments.At(0), out float x) || !float.TryParse(arguments.At(1), out float y))
            {
                response = "Invalid arguments X and Y must be floating-point numbers";
                return false;
            }

            if (x < Plugin.Instance.Config.MinXvalue || x > Plugin.Instance.Config.MaxXvalue || y < Plugin.Instance.Config.MinYvalue || y > Plugin.Instance.Config.MaxYvalue)
            {
                response = $"keep in mind x must be inbetween {Plugin.Instance.Config.MinXvalue}, {Plugin.Instance.Config.MaxXvalue} and y must be inbetween {Plugin.Instance.Config.MinYvalue}, {Plugin.Instance.Config.MaxYvalue}";
                return false;
            }

            SetPlayerScale(player, x, y);
            response = $"Your size set to X: {x}, Y: {y}!";
            return true;
        }

        private void SetPlayerScale(Player player, float x, float y)
        {
            player.Scale = new UnityEngine.Vector3(x, y, player.Scale.z);
        }

        public bool SanitizeResponse { get; } = false;
    }
}
