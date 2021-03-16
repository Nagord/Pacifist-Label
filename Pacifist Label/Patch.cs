using HarmonyLib;

namespace Pacifist_Label
{
    [HarmonyPatch(typeof(PLInGameUI), "Update")]
    class Patch
    {
        static void Postfix()
        {
            if (PLServer.Instance != null && PLServer.Instance.PacifistRun)
            {
                PLGlobal.SafeLabelSetText(PLInGameUI.Instance.CurrentVersionLabel, $"{PLInGameUI.Instance.CurrentVersionLabel.text} (Pacifist)");
            }
        }
    }
}
