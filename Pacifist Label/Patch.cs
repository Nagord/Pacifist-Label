//
// Outdated, this class is excluded.
//
using HarmonyLib;

namespace Pacifist_Label
{
    [HarmonyPatch(typeof(PLInGameUI), "Update")]
    class Patch
    {
         //Whether the game has recieved a message from host saying pacifist is true
        static void Postfix()//Runs code which sets pacifist label
        {
            //checks whether game is a pacifist run, and whether the client is the host, or the client has been told by the host.
            if (PLServer.Instance != null && (PhotonNetwork.isMasterClient && PLServer.Instance.PacifistRun || PacifistStatus))
            {
                PLGlobal.SafeLabelSetText(PLInGameUI.Instance.CurrentVersionLabel, $"{PLInGameUI.Instance.CurrentVersionLabel.text} (Pacifist)");
            }
        }
    }
}
