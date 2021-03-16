using PulsarPluginLoader;

namespace Pacifist_Label
{
    public class Plugin : PulsarPlugin
    {
        public override string Version => "1.0.0";

        public override string Author => "Dragon";

        public override string LongDescription => "Shows whether current run is pacifist";

        public override string Name => "PacifistLabel";

        public override string HarmonyIdentifier()
        {
            return "Dragon.PacifistLabel";
        }
    }
}
