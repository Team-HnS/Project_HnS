using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhoton : MonoBehaviour
{
    PhotonView pv;
    public GameObject cam;
    private void Awake()
    {
        pv = GetComponent<PhotonView>();
        if (pv.IsMine)
        { PlayerManager.instance.player = gameObject;}
        else
        {
            cam.SetActive(false);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
