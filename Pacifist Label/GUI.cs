using PulsarModLoader.CustomGUI;
using static UnityEngine.GUILayout;

namespace Pacifist_Label
{
    internal class GUI : ModSettingsMenu
    {
        private string PacifistString()
        {
            if (PLServer.Instance == null)
            {
                return "Pacifist Run: No Server"; 
            }
            if (PhotonNetwork.isMasterClient)
            {
                return "Pacifist Run: " + (PLServer.Instance.PacifistRun ? "Pacifist" : "Not Pacifist");
            }
            else if (RecievePacifistRunInfo.RecievedPacifistStatus)
            {
                return "Pacifist Run: " + (RecievePacifistRunInfo.PacifistStatus ? "Pacifist" : "Not Pacifist");
            }
            else
            {
                return "Pacifist Run: Unknown, no message recieved.";
            }
        }
        public override string Name()
        {
            return PacifistString();
        }

        public override void Draw()
        {
            Label(PacifistString());
        }
    }
}
