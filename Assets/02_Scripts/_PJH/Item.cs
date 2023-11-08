using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Item : MonoBehaviour
{
    public M_Item itemData;
    private TMP_Text nameTag;

    private void Start()
    {        
        nameTag = GetComponentInChildren<TMP_Text>();
        nameTag.text = itemData.ItemName;                
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);

        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        
    }
}
