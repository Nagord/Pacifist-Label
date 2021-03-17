using HarmonyLib;

namespace Pacifist_Label
{
    [HarmonyPatch(typeof(PLInGameUI), "Update")]
    class Patch
    {
        public static bool HasBeenToldStatus; //Whether the game has recieved a message from host saying pacifist is true
        static void Postfix()//Runs code which sets pacifist label
        {
            //checks whether game is a pacifist run, and whether the client is the host, or the client has been told by the host.
            if (PLServer.Instance != null && PLServer.Instance.PacifistRun && (HasBeenToldStatus || PhotonNetwork.isMasterClient))
            {
                PLGlobal.SafeLabelSetText(PLInGameUI.Instance.CurrentVersionLabel, $"{PLInGameUI.Instance.CurrentVersionLabel.text} (Pacifist)");
            }
        }
    }
}
