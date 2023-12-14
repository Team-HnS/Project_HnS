using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhoton : MonoBehaviourPunCallbacks
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

    [PunRPC]
    public void PlayerSetting(Vector3 pos, float rot)
    {
        gameObject.transform.position = pos;
        gameObject.GetComponent<PlayerMovement>().playerCharacter.gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, rot, 0));
    }

    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        Vector3 pos = gameObject.transform.position;
        float rot = gameObject.GetComponent<PlayerMovement>().playerCharacter.gameObject.transform.rotation.eulerAngles.y;
        print(rot);
        print(gameObject.GetComponent<PlayerMovement>().playerCharacter.gameObject.name);
        pv.RPC(nameof(PlayerSetting),RpcTarget.Others,pos,rot);
    }
}
