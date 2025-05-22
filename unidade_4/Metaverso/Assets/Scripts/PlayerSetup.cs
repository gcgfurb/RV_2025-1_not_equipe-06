using UnityEngine;
using Photon.Pun;

public class PlayerSetup : MonoBehaviour
{
    public Movement movement;

    public GameObject camera;

    public void IsLocalPlayer()
    {
        movement.enabled = true;
        camera.SetActive(true);
    }

    [PunRPC]
    public void SetNickname(string _name)
    {
        PhotonNetwork.LocalPlayer.NickName = _name;
    }
}
