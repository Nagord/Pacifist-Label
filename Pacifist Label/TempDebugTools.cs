using PulsarPluginLoader.Chat.Commands;

//
//This class is not included in the project.
//
namespace Pacifist_Label
{
    class TempCommands : IChatCommand
    {
        public override string[] CommandAliases()
        {
            return new string[] { "pldebug" };
        }

        public override string Description()
        {
            return "Gives debug data for pacifist label mod";
        }

        public override bool Execute(string arguments)
        {
            PulsarPluginLoader.Utilities.Messaging.Notification($"Current Pacifist state is {PLServer.Instance.PacifistRun}, Patch.PacifistStatus is {Patch.PacifistStatus}, Networking CachedPacifistRun is {UpdatePacifistRun.CachedPacifistRun}", PLNetworkManager.Instance.LocalPlayer, 0, 10000);
            return false;
        }
    }
}
