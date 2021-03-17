using PulsarPluginLoader.Chat.Commands;

namespace Pacifist_Label
{
    class TempCommands : IChatCommand
    {
        public string[] CommandAliases()
        {
            return new string[] { "pldebug" };
        }

        public string Description()
        {
            return "Temp commands for Pacifist Label. If you have this, get an updated version of the mod.";
        }

        public bool Execute(string arguments, int SenderID)
        {
            return false;
        }

        public bool PublicCommand()
        {
            PulsarPluginLoader.Utilities.Messaging.Notification($"Current Pacifist state is {PLServer.Instance.PacifistRun}, Patch.HasBeenToldStatus is {Patch.HasBeenToldStatus}, Networking CachedPacifistRun is {UpdatePacifistRun.CachedPacifistRun}", 0, 0, 10000);
            return false;
        }

        public string UsageExample()
        {
            return "";
        }
    }
}
