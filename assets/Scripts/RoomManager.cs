using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class RoomManager : MonoBehaviourPunCallbacks
{
    public GameObject player;

    [Space]
    public Transform SpawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Conecting...");
        PhotonNetwork.ConnectUsingSettings();
        
    }

 public override void OnConnectedToMaster() {
        base.OnConnectedToMaster();

        Debug.Log("Connected To Server!");

        PhotonNetwork.JoinLobby();

    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        PhotonNetwork.JoinOrCreateRoom("Public", null , null);
        Debug.Log("We're Connected and in a room now!");
        Invoke("PhotonInit", 10);
    }
    
    void PhotonInit() {
        GameObject _player = PhotonNetwork.Instantiate (player.name , SpawnPoint.position , Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
