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
            Debug.LogError("���� ī�޶� ã�� �� �����ϴ�.");
        }        
    }

    void Update()
    {
        transform.rotation = Cam.transform.rotation;
    }
}
