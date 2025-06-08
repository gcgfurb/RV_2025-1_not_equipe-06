using UnityEngine;
using Photon.Pun;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public GameObject player;

    [Space]
    public Transform spawnPoint;

    [Space]
    public GameObject nameUI;

    [Space]
    public Camera deactivateThis;

    [Space]
    public GameObject GameChat;

    [Space]
    public GameObject Conectando;

    [Space]
    public GameObject Texto;

    private string nickname = "Sr(a) sem nome";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    public void ChangeNickname(string _name)
    {
        nickname = _name;
    }

    public void JoinRoomButtonPressed()
    {
        Debug.Log("Connecting...");

        PhotonNetwork.ConnectUsingSettings();

        Conectando.SetActive(true);
        Texto.SetActive(false);
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();

        Debug.Log("Connected to Server");

        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();

        Debug.Log("We're in the lobby");

        PhotonNetwork.JoinOrCreateRoom("test", null, null);
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();

        Debug.Log("We're connected and in a room now");
        nameUI.SetActive(false);
        deactivateThis.enabled = false;

        GameObject _player = PhotonNetwork.Instantiate(player.name, spawnPoint.position, Quaternion.identity);
        _player.GetComponent<PlayerSetup>().IsLocalPlayer();

        _player.GetComponent<PhotonView>().RPC("SetNickname", RpcTarget.All, nickname);

        GameChat.SetActive(true);
    }
}
