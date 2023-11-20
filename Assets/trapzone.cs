using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapzone : MonoBehaviour
{
    public BoxCollider trapzone_C;
    public GameObject SpawnZone;



    private void OnTriggerEnter(Collider other)
    {

        SpawnZone.gameObject.SetActive(true);

    }
}
