using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSetting : MonoBehaviour
{

    public int BGMcode = 999;
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.instance.BgmPlay(BGMcode);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
