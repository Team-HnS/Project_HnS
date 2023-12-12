using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonTest : MonoBehaviourPunCallbacks
{
    public Transform Startpos;
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("���� ���� ����");
        RoomOptions options = new RoomOptions();
        options.MaxPlayers = 5;
        PhotonNetwork.JoinOrCreateRoom("Room1", options, null);



    }

    public override void OnJoinedRoom()
    {
        Debug.Log("�� ���� ����");

        PhotonNetwork.Instantiate("Prefabs/player Photon", Startpos.position,Quaternion.identity,0);
    }

}
