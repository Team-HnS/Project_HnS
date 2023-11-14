using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NpcNameHandler : MonoBehaviour
{


    public GameObject gameObject;
    
        private void Update()
        {
            gameObject.transform.forward = Camera.main.transform.forward;
        }
    
}
