using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookCam : MonoBehaviour
{
    public GameObject Cam;

    void Start()
    {
        FindMainCamera();
    }

    void FindMainCamera()
    {        
        Cam = Camera.main.gameObject;
        if (Cam == null)
        {
            Debug.LogError("메인 카메라를 찾을 수 없습니다.");
        }        
    }

    void Update()
    {
        transform.rotation = Cam.transform.rotation;
    }
}
