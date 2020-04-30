using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using System.IO;

public class networkedPlayerRight : MonoBehaviourPunCallbacks
{
    public GameObject HandAvatar;

    public Transform playerGlobal;
    public Transform playerLocal;

    void Start()
    {
        Debug.Log("Right is instantiated!");

        if (photonView.IsMine)
        {
            playerGlobal = GameObject.Find("NetworkPlayer").transform;
            playerLocal = playerGlobal.Find("OVRCameraRig/TrackingSpace/RightHandAnchor");


            this.transform.SetParent(playerLocal);
            this.transform.localPosition = Vector3.zero;


        }


    }
}