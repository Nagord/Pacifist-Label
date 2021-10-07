using PulsarModLoader;

namespace Pacifist_Label
{
    public class Mod : PulsarMod
    {
        public override string Version => "1.1.1";

        public override string Author => "Dragon";

        public override string LongDescription => "Shows whether current run is pacifist";

        public override string Name => "PacifistLabel";

        public override string HarmonyIdentifier()
        {
            return "Dragon.PacifistLabel";
        }
    }
}
