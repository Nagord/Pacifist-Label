using HarmonyLib;
using PulsarPluginLoader;

namespace Pacifist_Label
{
    class RecievePacifistRunInfo : ModMessage
    {
        public override void HandleRPC(object[] arguments, PhotonMessageInfo sender)
        {
            if (sender.sender == PhotonNetwork.masterClient)//checks the host sent the message and not some random client
            {
                if (!Patch.HasBeenToldStatus) //checks if hasbeentoldstatus has been updated before updating
                {
                    Patch.HasBeenToldStatus = true;
                }
                PLServer.Instance.PacifistRun = (bool)arguments[0];
            }
        }
    }
    [HarmonyPatch(typeof(PLServer), "LoginMessage")]
    class InitialSyncPatch //used to initially sync the client with the host's settings
    {
        static void Postfix(ref PhotonPlayer newPhotonPlayer)
        {
            if (PhotonNetwork.isMasterClient && ModMessageHelper.Instance.GetPlayerMods(newPhotonPlayer).Contains(ModMessageHelper.Instance.GetModName("PacifistLabel")))
            {
                ModMessage.SendRPC("Dragon.PacifistLabel", "Pacifist_Label.RecievePacifistRunInfo", newPhotonPlayer, new object[] { PLServer.Instance.PacifistRun });
            }
        }
    }
    [HarmonyPatch(typeof(PLServer), "Update")]
    class UpdatePacifistRun
    {
        public static bool CachedPacifistRun = true; //fixme make me private
        static void Postfix()//keeps client synced with host if Pacifist run state has changed
        {
            if (PhotonNetwork.isMasterClient && CachedPacifistRun != PLServer.Instance.PacifistRun)
            {//checks whether host needs to update clients (they should have been initially synced by the login message)
                CachedPacifistRun = PLServer.Instance.PacifistRun;
                foreach (PLPlayer player in PLServer.Instance.AllPlayers)
                {//for every player in PLServer.AllPlayers, check they have the mod and are not the local player before sending ModMessage containing current pacifist state.
                    PhotonPlayer photonplayer = player.GetPhotonPlayer();
                    if(ModMessageHelper.Instance.GetPlayerMods(photonplayer).Contains(ModMessageHelper.Instance.GetModName("PacifistLabel")) && photonplayer != PhotonNetwork.player)
                    {
                        ModMessage.SendRPC("Dragon.PacifistLabel", "Pacifist_Label.RecievePacifistRunInfo", photonplayer, new object[] { PLServer.Instance.PacifistRun });
                    }
                }
            }
        }
    }
}
