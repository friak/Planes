using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using System.IO;

public class networkController : MonoBehaviourPunCallbacks, IInRoomCallbacks
{

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }



    public override void OnConnectedToMaster()
    {
        Debug.Log("Player has connected to the Photon master server");
        PhotonNetwork.AutomaticallySyncScene = true;
        EnterRoom();
    }

    public void EnterRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Tried to join a random game but failed. There must be no open games available");
        CreateRoom();
    }


    void CreateRoom()
    {
        Debug.Log("Tring to create new room");
        int randomRoomName = Random.Range(0, 1);
        RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = 2 };
        PhotonNetwork.CreateRoom("Planes Room" + randomRoomName, roomOps);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("You have now entered a room");
        PhotonNetwork.Instantiate(Path.Combine("Prefab", "CustomHandLeft"), transform.position, Quaternion.identity, 0);
        PhotonNetwork.Instantiate(Path.Combine("Prefab", "CustomHandRight"), transform.position, Quaternion.identity, 0);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Tried to create a new room but failed, there must already be a room with the same name");
        CreateRoom();
    }
}
