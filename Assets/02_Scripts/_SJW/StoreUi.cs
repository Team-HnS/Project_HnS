using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreUi : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        ItemManager.Instance.UpdateCoinUI();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
