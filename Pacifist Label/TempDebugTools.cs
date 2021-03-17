using PulsarPluginLoader.Chat.Commands;

//
//This class is not included in the project.
//
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
            return "Gives debug data for pacifist label mod";
        }

        public bool Execute(string arguments, int SenderID)
        {
            return false;
        }

        public bool PublicCommand()
        {
            PulsarPluginLoader.Utilities.Messaging.Notification($"Current Pacifist state is {PLServer.Instance.PacifistRun}, Patch.PacifistStatus is {Patch.PacifistStatus}, Networking CachedPacifistRun is {UpdatePacifistRun.CachedPacifistRun}", PLNetworkManager.Instance.LocalPlayer, 0, 10000);
            return false;
        }

        public string UsageExample()
        {
            return "/pldebug";
        }
    }
}
